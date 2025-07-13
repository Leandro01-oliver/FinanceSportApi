# Implementação do ASP.NET Core Identity

Este documento descreve a implementação do ASP.NET Core Identity no projeto FinanceSportApi.

## Configurações Realizadas

### 1. Dependências Adicionadas

#### FinanceSportApi.Domain
- `Microsoft.AspNetCore.Identity.EntityFrameworkCore` (8.0.13)

#### FinanceSportApi.Infra.Data
- `Microsoft.AspNetCore.Identity.EntityFrameworkCore` (8.0.13)

#### FinanceSportApi.Service
- `Microsoft.AspNetCore.Identity` (2.3.1)

#### FinanceSportApi (Projeto Principal)
- `Microsoft.AspNetCore.Authentication.JwtBearer` (8.0.13)

### 2. Modificações no DataContext

O `DataContext` agora herda de `IdentityDbContext<Usuario>` em vez de `DbContext`:

```csharp
public class DataContext : IdentityDbContext<Usuario>
{
    // O Identity gerencia automaticamente as tabelas de usuários
    // Não precisamos mais do DbSet<Usuario>
}
```

### 3. Configuração do Identity

No arquivo `DataContextDbExtension.cs`, foi adicionada a configuração do Identity:

```csharp
services.AddIdentity<Usuario, IdentityRole>(options =>
{
    // Configurações de senha
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;

    // Configurações de usuário
    options.User.RequireUniqueEmail = true;

    // Configurações de lockout
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
})
.AddEntityFrameworkStores<DataContext>()
.AddDefaultTokenProviders();
```

### 4. Configuração JWT

No `Program.cs`, foi adicionada a autenticação JWT:

```csharp
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"])),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ClockSkew = TimeSpan.Zero
        };
    });
```

### 5. Configuração JWT no appsettings

Adicionado no `appsettings.Development.json`:

```json
{
  "Jwt": {
    "Key": "SuaChaveSecretaMuitoLongaParaJWT2024FinanceSportApi",
    "Issuer": "FinanceSportApi",
    "Audience": "FinanceSportApiUsers",
    "ExpirationHours": 12
  }
}
```

## Endpoints Disponíveis

### AccountController

#### POST /api/account/create-roles
Cria as roles padrão do sistema (Admin, Usuario).

#### POST /api/account/register
Registra um novo usuário e retorna um token JWT.

**Request Body:**
```json
{
  "nome": "Nome do Usuário",
  "email": "usuario@email.com",
  "senha": "Senha123!",
  "telefone": "11999999999"
}
```

#### POST /api/account/login
Realiza login com email e senha.

**Request Body:**
```json
{
  "email": "usuario@email.com",
  "senha": "Senha123!"
}
```

#### POST /api/account/login-google
Realiza login com dados do Google.

**Request Body:**
```json
{
  "email": "usuario@gmail.com",
  "nome": "Nome do Usuário"
}
```

#### POST /api/account/validate-token
Valida um token JWT.

#### PUT /api/account/update-last-login
Atualiza o último login do usuário (requer autenticação).

## Funcionalidades do Identity

### 1. Gerenciamento de Usuários
- Criação de usuários com senha criptografada
- Validação de email único
- Confirmação de email (opcional)
- Bloqueio de conta após tentativas falhadas

### 2. Gerenciamento de Roles
- Roles padrão: "Admin" e "Usuario"
- Atribuição automática de role "Usuario" para novos usuários
- Suporte a múltiplas roles por usuário

### 3. Autenticação JWT
- Tokens com claims personalizadas
- Expiração configurável
- Validação de issuer e audience
- Claims incluindo ID do usuário, email, nome e tipo de usuário

### 4. Segurança
- Senhas com requisitos mínimos
- Lockout automático
- Tokens seguros com chave secreta

## Migrations Necessárias

Após a implementação, será necessário criar uma nova migration para incluir as tabelas do Identity:

```bash
dotnet ef migrations add AddIdentityTables
dotnet ef database update
```

## Uso das Roles

### Proteção de Endpoints

```csharp
[Authorize(Roles = "Admin")]
public async Task<IActionResult> AdminOnlyEndpoint()
{
    // Apenas usuários com role Admin podem acessar
}

[Authorize(Roles = "Usuario")]
public async Task<IActionResult> UserEndpoint()
{
    // Apenas usuários com role Usuario podem acessar
}
```

### Verificação de Roles no Código

```csharp
if (User.IsInRole("Admin"))
{
    // Lógica para administradores
}
```

## Próximos Passos

1. Executar as migrations para criar as tabelas do Identity
2. Testar os endpoints de registro e login
3. Configurar o Swagger para incluir autenticação JWT
4. Implementar refresh tokens se necessário
5. Adicionar validações adicionais conforme necessário 
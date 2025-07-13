# Configuração do Swagger com Autenticação JWT

## Visão Geral

A API Finance Sport agora está configurada com autenticação JWT no Swagger UI, permitindo testar endpoints protegidos diretamente na interface do Swagger.

## Como Usar

### 1. Acessar o Swagger UI

1. Execute a aplicação
2. Acesse: `https://localhost:port/swagger`
3. Você verá a interface do Swagger com um botão "Authorize" no topo

### 2. Obter um Token JWT

1. Use o endpoint `/api/Account/login` para fazer login:
   ```json
   {
     "email": "seu@email.com",
     "senha": "suaSenha123!"
   }
   ```

2. Ou use o endpoint `/api/Account/register` para criar uma conta:
   ```json
   {
     "nome": "Seu Nome",
     "email": "seu@email.com",
     "senha": "suaSenha123!",
     "tipoUsuario": 1
   }
   ```

3. A resposta incluirá o token JWT:
   ```json
   {
     "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
     "expiraEm": "2024-01-01T12:00:00",
     "email": "seu@email.com",
     "nome": "Seu Nome"
   }
   ```

### 3. Configurar Autenticação no Swagger

1. Clique no botão **"Authorize"** no topo da página do Swagger
2. No campo "Value", digite: `Bearer {seu_token}`
   - Exemplo: `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...`
3. Clique em **"Authorize"**
4. Clique em **"Close"**

### 4. Testar Endpoints Protegidos

Agora você pode testar todos os endpoints que requerem autenticação:

- **GET** `/api/Usuario` - Listar usuários (requer role "Usuario")
- **GET** `/api/Usuario/{id}` - Obter usuário por ID (requer role "Usuario")
- **POST** `/api/Usuario` - Criar usuário (requer role "Usuario")
- **PUT** `/api/Usuario/{id}` - Atualizar usuário (requer role "Usuario")
- **DELETE** `/api/Usuario/{id}` - Excluir usuário (requer role "Admin")
- **PUT** `/api/Account/update-last-login` - Atualizar último login (requer autenticação)

## Endpoints Públicos

Os seguintes endpoints não requerem autenticação:

- **POST** `/api/Account/create-roles` - Criar roles do sistema
- **POST** `/api/Account/register` - Registrar novo usuário
- **POST** `/api/Account/login` - Fazer login
- **POST** `/api/Account/login-google` - Login com Google
- **POST** `/api/Account/validate-token` - Validar token

## Roles do Sistema

- **Usuario**: Acesso básico aos recursos
- **Admin**: Acesso completo, incluindo exclusão de usuários

## Configuração Técnica

A configuração do Swagger com JWT foi implementada através da extensão `SwaggerExtension.cs` que:

1. Adiciona definição de segurança Bearer
2. Configura o esquema de autenticação JWT
3. Aplica o requisito de segurança globalmente
4. Inclui documentação XML quando disponível

## Troubleshooting

### Token Expirado
Se receber erro 401, o token pode ter expirado. Faça login novamente para obter um novo token.

### Role Insuficiente
Se receber erro 403, verifique se o usuário tem a role necessária para o endpoint.

### Token Inválido
Certifique-se de incluir "Bearer " antes do token no campo de autorização. 
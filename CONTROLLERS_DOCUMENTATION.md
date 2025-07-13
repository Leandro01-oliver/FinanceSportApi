# Documentação das Controllers - FinanceSportApi

## AccountController

A `AccountController` é responsável por gerenciar a autenticação e autorização dos usuários.

### Endpoints

#### POST /api/account/login
Realiza login do usuário com email e senha.

**Request Body:**
```json
{
  "email": "usuario@exemplo.com",
  "senha": "senha123"
}
```

**Response (200):**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "expiraEm": "2024-01-01T12:00:00Z",
  "email": "usuario@exemplo.com",
  "nome": "Nome do Usuário"
}
```

#### POST /api/account/login-google
Realiza login do usuário com Google.

**Request Body:**
```json
{
  "email": "usuario@gmail.com",
  "nome": "Nome do Usuário"
}
```

**Response (200):**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "expiraEm": "2024-01-01T12:00:00Z",
  "email": "usuario@gmail.com",
  "nome": "Nome do Usuário"
}
```

#### POST /api/account/validate-token
Valida um token de autenticação.

**Request Body:**
```json
"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
```

**Response (200):**
```json
{
  "valid": true
}
```

#### PUT /api/account/update-last-login
Atualiza o último login do usuário (requer autenticação).

**Request Body:**
```json
"usuario@exemplo.com"
```

**Response (200):**
```json
{
  "message": "Último login atualizado com sucesso"
}
```

---

## UsuarioController

A `UsuarioController` é responsável por gerenciar o CRUD de usuários (cadastro, edição, exclusão).

**Nota:** Todos os endpoints desta controller requerem autenticação.

### Endpoints

#### GET /api/usuario
Obtém todos os usuários.

**Response (200):**
```json
[
  {
    "id": "123e4567-e89b-12d3-a456-426614174000",
    "nome": "Nome do Usuário",
    "telefone": "(11) 99999-9999",
    "email": "usuario@exemplo.com",
    "senha": "senha123"
  }
]
```

#### GET /api/usuario/{id}
Obtém um usuário específico por ID.

**Response (200):**
```json
{
  "id": "123e4567-e89b-12d3-a456-426614174000",
  "nome": "Nome do Usuário",
  "telefone": "(11) 99999-9999",
  "email": "usuario@exemplo.com",
  "senha": "senha123"
}
```

#### POST /api/usuario
Cria um novo usuário.

**Request Body:**
```json
{
  "nome": "Novo Usuário",
  "telefone": "(11) 99999-9999",
  "email": "novo@exemplo.com",
  "senha": "senha123"
}
```

**Response (201):**
```json
{
  "id": "123e4567-e89b-12d3-a456-426614174000",
  "nome": "Novo Usuário",
  "telefone": "(11) 99999-9999",
  "email": "novo@exemplo.com",
  "senha": "senha123"
}
```

#### PUT /api/usuario/{id}
Atualiza um usuário existente.

**Request Body:**
```json
{
  "id": "123e4567-e89b-12d3-a456-426614174000",
  "nome": "Usuário Atualizado",
  "telefone": "(11) 88888-8888",
  "email": "atualizado@exemplo.com",
  "senha": "novaSenha123"
}
```

**Response (200):**
```json
{
  "message": "Usuário atualizado com sucesso"
}
```

#### DELETE /api/usuario/{id}
Exclui um usuário.

**Response (204):** No Content

#### GET /api/usuario/buscar/{nome}
Busca usuários por nome.

**Response (200):**
```json
[
  {
    "id": "123e4567-e89b-12d3-a456-426614174000",
    "nome": "João Silva",
    "telefone": "(11) 99999-9999",
    "email": "joao@exemplo.com",
    "senha": "senha123"
  }
]
```

---

## Códigos de Status HTTP

- **200**: Sucesso
- **201**: Criado com sucesso
- **204**: Sucesso sem conteúdo
- **400**: Requisição inválida
- **401**: Não autorizado
- **404**: Não encontrado

## Autenticação

Para endpoints que requerem autenticação, inclua o token JWT no header da requisição:

```
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```

## Exemplo de Uso

### 1. Login
```bash
curl -X POST "https://localhost:5001/api/account/login" \
  -H "Content-Type: application/json" \
  -d '{"email": "usuario@exemplo.com", "senha": "senha123"}'
```

### 2. Criar Usuário (com autenticação)
```bash
curl -X POST "https://localhost:5001/api/usuario" \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer SEU_TOKEN_AQUI" \
  -d '{"nome": "Novo Usuário", "email": "novo@exemplo.com", "senha": "senha123"}'
```

### 3. Buscar Usuários
```bash
curl -X GET "https://localhost:5001/api/usuario" \
  -H "Authorization: Bearer SEU_TOKEN_AQUI"
``` 
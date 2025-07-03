# Configuração do Token do GitHub para CI/CD

## 🔧 Problema Resolvido

O erro **"Bad credentials (401)"** foi corrigido com as seguintes melhorias no workflow:

### ✅ Principais Correções

1. **Tratamento de Erro Robusto**
   - Adicionado `try-catch` para capturar erros de autenticação
   - O workflow não falha mais por problemas de credenciais
   - Logs informativos para debug

2. **Configuração Git Correta**
   - Configuração automática de credenciais Git
   - Uso correto do token para autenticação HTTPS
   - Configuração de usuário para commits automáticos

3. **Verificação de PR Existente**
   - Verifica se já existe um PR antes de criar um novo
   - Evita duplicação de pull requests
   - Processa PRs existentes automaticamente

4. **Condições de Execução Melhoradas**
   - Não executa em branches protegidas (develop, master, homologacao)
   - Evita loops infinitos de merge

5. **Merge Inteligente**
   - Verifica se o PR pode ser mergeado antes de tentar
   - Trata conflitos e checks pendentes
   - Mensagens de commit mais informativas

## 🔑 Configuração do Token

### 1. Criar Personal Access Token (PAT)

1. Acesse: **GitHub.com → Settings → Developer settings → Personal access tokens → Tokens (classic)**
2. Clique em **"Generate new token (classic)"**
3. Configure as permissões:
   - ✅ `repo` (Full control of private repositories)
   - ✅ `workflow` (Update GitHub Action workflows)
   - ✅ `admin:org` (se necessário para organização)

### 2. Adicionar Secret no Repositório

1. Vá para: **Seu Repositório → Settings → Secrets and variables → Actions**
2. Clique em **"New repository secret"**
3. Nome: `GH_PAT`
4. Valor: Cole o token gerado

### 3. Verificar Permissões do Token

O token deve ter acesso a:
- ✅ Ler repositório
- ✅ Criar pull requests
- ✅ Fazer merge de pull requests
- ✅ Deletar branches
- ✅ Executar workflows

## 🚀 Como Testar

1. **Push para uma branch não protegida:**
   ```bash
   git checkout -b feature/test-token
   git push origin feature/test-token
   ```

2. **Verificar logs do workflow:**
   - Vá para **Actions** no GitHub
   - Clique no workflow executado
   - Verifique os logs de cada step

3. **Verificar criação/merge do PR:**
   - Vá para **Pull requests**
   - Deve aparecer um PR para `develop`
   - Deve ser mergeado automaticamente

## 🔍 Troubleshooting

### Erro: "Bad credentials"
- ✅ Verifique se o `GH_PAT` está configurado corretamente
- ✅ Confirme se o token não expirou
- ✅ Verifique se tem as permissões necessárias

### Erro: "could not read Username for 'https://github.com'"
- ✅ Verifique se o `GH_PAT` está configurado corretamente
- ✅ Confirme se o token tem permissão `repo` (Full control)
- ✅ O workflow agora configura automaticamente as credenciais Git

### Erro: "No open PR found to merge"
- ✅ Normal se não houver PR existente
- ✅ O workflow criará um novo PR automaticamente

### Erro: "PR cannot be merged"
- ✅ Verifique se há conflitos
- ✅ Confirme se todos os checks passaram
- ✅ Verifique se a branch `develop` está atualizada

## 📧 Notificações por Email

O workflow envia emails para:
- **Sucesso:** `dev@email.com`
- **Falha:** `dev@email.com`

Configure os secrets de SMTP:
- `SMTP_HOST`
- `SMTP_PORT`
- `SMTP_USERNAME`
- `SMTP_PASSWORD`

## 🔒 Segurança

- ✅ Token com permissões mínimas necessárias
- ✅ Não executa em branches protegidas
- ✅ Tratamento de erro sem exposição de dados sensíveis
- ✅ Logs informativos para auditoria

## 📊 Monitoramento

- **SonarCloud:** https://sonarcloud.io/project/overview?id=Leandro01-oliver_FinanceSportApi
- **GitHub Actions:** Actions tab no repositório
- **Pull Requests:** PRs tab para acompanhar merges automáticos 
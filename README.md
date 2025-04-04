# DependencyInjectionDemonstration

## 🔧 Injeção de Dependência no ASP.NET Core

### Como escolher o tempo de vida (lifetime) ideal?

Transient:
- ➤ Um novo objeto é criado toda vez que for solicitado.
- ➤ Use quando o serviço NÃO mantém estado e é leve de criar.

Scoped:
- ➤ Uma instância é criada por requisição HTTP.
- ➤ Ideal para serviços que precisam compartilhar dados dentro da mesma requisição.

Singleton:
- ➤ Uma única instância é usada durante toda a vida da aplicação.
- ➤ Use quando o serviço deve ser compartilhado e é thread-safe.
---
# 🌍 Escopos no ASP.NET Core

No ASP.NET Core, os serviços registrados no container de injeção de dependência (DI) podem pertencer a diferentes escopos. Os principais são:

## 🏠 1. Root Scope (Escopo Raiz)

O **Root Scope** (ou **container root**) é criado **quando a aplicação inicia** e dura **até a aplicação ser encerrada**.

- Todos os serviços **Singleton** pertencem ao **Root Scope**.
- Qualquer serviço registrado **fora de uma requisição HTTP** será resolvido dentro do **Root Scope**.
- Se um serviço **Transient for resolvido no Root Scope**, ele **não será descartado automaticamente**, podendo causar vazamento de memória.

---

## 🌍 2. Request Scope (Escopo de Requisição)

No ASP.NET Core, **um novo escopo é criado automaticamente para cada requisição HTTP**.

- Todos os serviços **Scoped** pertencem a este **Request Scope**.
- Qualquer serviço **Transient** e **Scoped** criado dentro da requisição **será descartado ao fim da requisição**.
- **Cada requisição tem seu próprio escopo**, ou seja, serviços `Scoped` são **compartilhados dentro da mesma requisição**, mas **não entre requisições diferentes**.

---

## ⚠️ Problema: Injetar Scoped no Root Scope

Se um **Singleton** depende de um serviço `Scoped`, ele estará tentando acessar algo que foi criado **dentro de um escopo que pode já ter sido descartado**, causando **comportamento inesperado** ou **erros de execução**.

### ❌ Problema:
- Um `Scoped` injetado diretamente em um `Singleton` pode ser descartado antes de ser utilizado.

### ✅ Solução:
- Sempre resolver serviços `Scoped` **dentro de um escopo válido**, por exemplo, criando um novo escopo manualmente (`CreateScope()`) dentro do método que precisa dele.

---

## 🎯 Resumo dos Escopos

| **Tipo de Escopo**      | **Criado Quando?** | **Válido Até**  | **Exemplo de Serviços** |
|------------------------|-------------------|----------------|------------------------|
| **Root Scope** (Container Root) | Quando a aplicação inicia | Até o app ser encerrado | `Singletons` |
| **Request Scope** (Escopo de Requisição) | Quando uma requisição HTTP começa | Até o fim da requisição | `Scoped`, `Transient` |

> **Regra de Ouro:** Nunca injetar `Scoped` em `Singleton` diretamente!  
> Sempre crie um escopo (`CreateScope()`) dentro do método que precisa dele.

---

### Compatibilidade de Injeção de Dependência por Tempo de Vida

| Serviço Consumidor ↓ / Dependência → | Transient | Scoped | Singleton |
|--------------------------------------|-----------|--------|-----------|
| **Transient**                        | ✅        | ✅     | ✅        |
| **Scoped**                           | ✅        | ✅     | ✅        |
| **Singleton**                        | ✅        | ❌     | ✅        |

**Legenda:**
- ✅ Permitido: A injeção é válida.
- ❌ Inválido: Pode causar erro de tempo de execução.

**Regras de ouro:**
- Singleton não pode depender de Scoped.
- Scoped pode depender de Scoped e Singleton.
- Transient pode depender de qualquer um.

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
## ♻️ O que é um serviço Scoped?

No ASP.NET Core, um serviço registrado como `Scoped` tem **um ciclo de vida por requisição HTTP**.

Ou seja:

- Durante **uma requisição**, o container injeta **a mesma instância** do serviço sempre que ele for solicitado.
- Em **outra requisição**, uma **nova instância** será criada.

### 📌 Exemplo prático:

Se você tiver um serviço com `Guid.NewGuid()` registrado como `Scoped`, ele vai gerar o **mesmo GUID durante toda a requisição**, mas um novo GUID em cada nova requisição.

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

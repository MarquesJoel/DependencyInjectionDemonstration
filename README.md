# DependencyInjectionDemonstration

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

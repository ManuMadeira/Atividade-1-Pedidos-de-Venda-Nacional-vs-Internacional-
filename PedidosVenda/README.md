# Sistema de Processamento de Pedidos

## Como Executar
1. Clone o repositório
2. Execute \dotnet build\ para compilar
3. Execute \dotnet test\ para rodar os testes

## Decisões de Design
- **Herança**: Utilizada para especializar o ritual fixo de processamento (Validar → Calcular → Emitir), com variações entre pedidos nacionais e internacionais.
- **Composição**: Implementada via delegates para políticas flexíveis de frete e promoção, permitindo combinações sem criar novas subclasses.

## Testes Incluídos
- **LSP**: Demonstra substituição transparente entre tipos de pedido
- **Composição**: Mostra troca de políticas sem alterar estrutura de classes

## Estrutura Principal
- \Pedido\ (base) - Orquestra o ritual fixo
- \PedidoNacional\ / \PedidoInternacional\ (sealed) - Especializam cálculo e formato
- Delegates \Frete\ e \Promocao\ - Políticas plugáveis

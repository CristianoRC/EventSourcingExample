# EventSourcingExample
Exemplo de uma conta corrente usando Event Sourcing

## Slides

[![Slides](https://i.imgur.com/YhFxEIl.png)](https://www.slideshare.net/CristianoRaffiCunha/event-sourcing-e-cqrs)

## Criando o banco

`docker run --name esdb-node -it -p 2113:2113 -p 1113:1113 -e EVENTSTORE_DISABLE_INTERNAL_TCP_TLS=True -e VENTSTORE_DISABLE_EXTERNAL_TCP_TLS=True  eventstore/eventstore:latest --insecure --run-projections=All`


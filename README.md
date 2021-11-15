# EventSourcingExample
Exemplo de uma conta corrente usando Event Sourcing

Criando o banco: `docker run --name esdb-node -it -p 2113:2113 -p 1113:1113 -e EVENTSTORE_DISABLE_INTERNAL_TCP_TLS=True -e VENTSTORE_DISABLE_EXTERNAL_TCP_TLS=True  eventstore/eventstore:latest --insecure --run-projections=All`

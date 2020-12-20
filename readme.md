
## Para subir o aplicativo
Os serviços estão containerzados e orquestrados com docker compose. Clone o repositório e na pasta raiz (onde está o arquivo docker-compose.yml) e execute um "docker-compose up" com os parametros desejados ou utilize uma ferramenta de gerenciamento de containers. O yml não possui nenhum healthcheck, mas os containers da API e do banco de dados vão reiniciar caso falhem.

obs: são containers linux.

### Containers
Os containers configurados são:
- database(mysql)
- elasitcsearch
- kibana (opcional)
- mutanttestapi(.net core 3.1)

caso não deseje usar o kibana para verificar os logs no elasticsearch, este serviço pode ser removido do docker-compose.yml. Nenhum outro serviço depende dele.

## Para testar
http://localhost/swagger
A porta 80 do container já está mapeada para a porta 80 do host.

possui duas ações:

**GET /users/download**

Recupera todas as informações da API externa, e apresenta sem filtros.

Retorna 200

**POST /users/save**

Salva os dados no banco. A UNIQUE CONSTRAINT é o endereço de e-mail. As entradas são inseridas uma a uma. Apesar de um pouco menos performático isso permite inserção parcial de dados, ou seja, em cada batch serão inseridos os dados válidos. Se houverem duplicatas elas serão descartadas e os novos registros serão inseridos.

Retorna um 201 apenas com os dados que de fato foram inseridos.

Retorna um 409 se todos os dados forem duplicados.

## Logs
### Em arquivo txt
O container da API possui um mapeamento de volume para a pasta "Logs" na raiz do projeto (proxima ao arquivo docker-compose.yml). Nesta pasta será criado um arquivo TXT por dia com os logs do app.
### Elasticsearch
Os logs estão alocados no índice "logstash-@timestamp". Se utilizar o kibana, acesse http://localhost:5601 (a porta já está mapeada) e este index pattern. (clique em discover, create index pattern, defina logstash-* em seguida @timestamp)

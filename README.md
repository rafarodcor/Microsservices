# Arquitetura de Microsserviços

Curso de Microsserviços do Macoratti

Todas as APIs, bancos e serviços foram conteinerizados com Docker Compose.

Projetos e ferramentas utilizadas em cada um:

# Basket.API (Cesto ou carrinho)
- Redis
- gRPC (Client)

# Catalog.API (Catálogo de produtos)
- MongoDB

# Discount.API (Cadastro de descontos para produtos)
- Postgre
- NpgSQL (utilizado para criar Server=DiscountServer, Database=Discountdb e a Table=Coupon(Id SERIAL PRIMARY KEY, ProductName VARCHAR(24) NOT NULL, Description TEXT, Amount INT)
- Dapper

  # Discount.gRPC (Aplicação responsável pelos descontos)
- Postgre
- Dapper
- Automapper
- gRPC (Server)

Comando no terminal:
docker-compose -f docker-compose.yml -f docker-compose.override.yml up --build

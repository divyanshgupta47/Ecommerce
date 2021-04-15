IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'Ecommerce')
  BEGIN
    CREATE  DATABASE  Ecommerce;
  END
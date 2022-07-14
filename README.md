# Teste-LG

# Exercício 3a: Faça uma consulta SQL que retorne a soma dos salários dos funcionários agrupados por empresa.
# SELECT e.Descricao, SUM(f.Salario) AS Total
# FROM Empresa e INNER JOIN
#     Funcionario f
#     ON e.Codigo = f.CodigoEmpresa
# GROUP BY e.Descricao

# Exercício 3b: Faça uma consulta SQL que retorne o nome das empresas que possuem mais de 30 funcionários.
# SELECT e.Descricao
# FROM Empresa e INNER JOIN
#     Funcionario f
#     ON e.Codigo = f.CodigoEmpresa
# WHERE COUNT(f.Codigo) > 30

# Exercício 3c: Faça uma consulta SQL que retorne o nome do funcionário, o código e a descrição do centro de custos e o código e a descrição do seu cargo.
# SELECT f.Nome, cc.Codigo, cc.Descricao, c.Codigo, c.Descricao
# FROM Cargo c INNER JOIN
#     Funcionario f 
#     ON c.Codigo = f.CodigoCargo
#     INNER JOIN CentroDeCusto cc
#     ON cc.Codigo = f.CodigoCentroDeCusto

# Exercício 3d: Faça uma consulta SQL que retorne todos os funcionários que não possuem dependentes.
# SELECT *
# FROM Funcionario f INNER JOIN
#     Dependente d 
#     ON f.Codigo = d.CodigoFuncionario
# WHERE d.CodigoFuncionario IS null

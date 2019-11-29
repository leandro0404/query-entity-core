# query-entity-core


```sql

	SELECT [tipoparte].[CodigoTipoParte], [tipoparte].[Descricao], [classes].[CodigoClasse], [tipoparte].[CodigoTipoParte] AS [CodigoTipoParte0], [classes].[Tipo], CASE
	WHEN [classes].[CodigoTipoParte] = [tipoparte].[CodigoTipoParte]
	THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT)
	END, CASE
	WHEN [classes].[CodigoTipoParte] = [tipoparte].[CodigoTipoParte]
	THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT)
	END AS [ExisteVinculo]
	FROM [ClasseTipoParte] AS [classes]
	LEFT JOIN [TipoParte] AS [tipoparte] ON 1 = 1



	exec sp_executesql N'SELECT [t1].[CodigoTipoParte], [t1].[Descricao], [t4].[CodigoClasse], [t4].[CodigoTipoParte], [t4].[Tipo]
    FROM(
        SELECT DISTINCT[t0].*
        FROM(
            SELECT[t].*
            FROM(
                SELECT TOP(@__p_0)[p].[CodigoTipoParte], [p].[Descricao]
                FROM[TipoParte] AS[p]
                ORDER BY[p].[CodigoTipoParte]
            ) AS[t]
            ORDER BY[t].[CodigoTipoParte]
            OFFSET @__p_1 ROWS
        ) AS[t0]
    ) AS[t1]
    LEFT JOIN(
        SELECT DISTINCT [t3].*
        FROM(
            SELECT[t2].*
            FROM(
                SELECT TOP(@__p_0)[p0].*
                FROM[ClasseTipoParte] AS[p0]
                ORDER BY[p0].[CodigoClasse]
            ) AS[t2]
            ORDER BY[t2].[CodigoClasse]
            OFFSET @__p_1 ROWS
        ) AS[t3]
    ) AS[t4] ON 1 = 1',N'@__p_0 int, @__p_1 int',@__p_0=15,@__p_1=0
```
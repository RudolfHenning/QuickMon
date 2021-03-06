SELECT top(@top) 
	[InsertDate],
	[AlertLevel],
	[CollectorType],
	[Category],
	[PreviousState],
	[CurrentState],
	[Details]
FROM
	[AlertMessages]
WHERE 
	[InsertDate] between @FromDate and @ToDate and
	(@AlertLevel is null or [AlertLevel] >= @AlertLevel) and
	(@CollectorType is null or [CollectorType] like @CollectorType) and
	(@Category is null or [Category] like @Category) and
	(@CurrentState is null or [CurrentState] = @CurrentState) and
	(@Details is null or [Details] like @Details)
ORDER BY
	[InsertDate] desc
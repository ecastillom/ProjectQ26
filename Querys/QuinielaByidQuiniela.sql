SELECT
	EL.EquipoImgURL AS EquipoLocalImgURL,
	EL.EquipoName AS EquipoLocal,
	EV.EquipoImgURL AS EquipoVisitanteImgURL,
	EV.EquipoName AS EquipoVisitante
FROM Quinielas AS Q 
INNER JOIN QuinielasDetalle AS QD 
ON Q.idQuiniela = QD.idQuiniela 
INNER JOIN Jornadas AS J
ON QD.idJornada = J.idJornada 
INNER JOIN JornadasPartidos AS JP
ON J.idJornada = JP.idJornada 
INNER JOIN Partidos AS P
ON JP.idPartido = P.idPartido 
INNER JOIN Equipos AS EL
ON P.idEquipoLocal = EL.idEquipo 
INNER JOIN Equipos AS EV 
ON P.idEquipoVisitante = EV.idEquipo
WHERE Q.idQuiniela = @idQuiniela

select * from statusprocess
insert into StatusProcess
select 'Capturada','Capture',1,1,getdate()
insert into StatusProcess
select 'Guardada','Saved',1,1,getdate()
insert into StatusProcess
select 'En Proceso','In Process',1,1,getdate()
insert into StatusProcess
select 'Abierta','Open',1,1,getdate()
insert into StatusProcess
select 'Enviada','Sent',1,1,getdate()
insert into StatusProcess
select 'Cerrada','Closed',1,1,getdate()
insert into StatusProcess
select 'Cancelada','Cancel',1,1,getdate()
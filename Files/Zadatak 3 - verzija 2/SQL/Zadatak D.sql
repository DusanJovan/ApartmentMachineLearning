select city as grad, count(case when action_type = 1 then 1 else null end) as prodaja ,
(count(case when action_type = 1 then 1 else null end) * 100.0 / (count(*))) as prodaja_procenat,
count(case when action_type = 2 then 1 else null end) as iznajmljivanje ,
(count(case when action_type = 2 then 1 else null end) * 100.0 / (count(*))) as iznajmljivanje_procenat
from apartments 
group by city
order by count(*) desc limit 5
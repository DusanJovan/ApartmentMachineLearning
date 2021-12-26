select 
COUNT(case when a.action_type = 1 THEN 1 ELSE NULL END) as prodaja,
COUNT(case when a.action_type = 2 THEN 1 ELSE NULL END) as izdavanje
from apartments a

--prodaja|izdavanje|
---------+---------+
--  16607|     4393|
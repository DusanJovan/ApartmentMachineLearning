select COUNT(case when a.apartment_type = 2 and a.registered THEN 1 ELSE NULL END) uknjizene_kuce,
		COUNT(case when a.apartment_type = 2 and not a.registered THEN 1 ELSE NULL END) neuknjizene_kuce,
		COUNT(case when a.apartment_type = 1 and a.registered THEN 1 ELSE NULL END) uknjizeni_stanovi,
		COUNT(case when a.apartment_type = 1 and not a.registered THEN 1 ELSE NULL END) neuknjizeni_stanovi
from apartments a 

--uknjizene_kuce|neuknjizene_kuce|uknjizeni_stanovi|neuknjizeni_stanovi|
----------------+----------------+-----------------+-------------------+
--          2269|            1230|             8871|               8630|
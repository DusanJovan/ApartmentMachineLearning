select count(case when parking = true then 1 else null end) parking from apartments a where city ilike 'beograd' and action_type = 1 group by city
union
select count(case when parking = false then 1 else null end) ukupno from apartments where city ilike 'beograd' and action_type = 1 group by city
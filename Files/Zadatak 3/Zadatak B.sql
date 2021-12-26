select t.range as raspon_kvadrature, count(*) as  broj_nekretnina
from ( 
  select case  
    when apartment_area <= 35 then '<35'
    when apartment_area > 35 and apartment_area <= 50 then '35-50'
    when apartment_area > 50 and apartment_area <= 65 then '50-65'
    when apartment_area > 65 and apartment_area <= 80 then '65-80'
    when apartment_area > 80 and apartment_area <= 95 then '80-98'
    when apartment_area > 95 and apartment_area <= 110 then '95-110'
    else '>111' end as range
  from apartments
  where apartment_type = 1) t
group by t.range
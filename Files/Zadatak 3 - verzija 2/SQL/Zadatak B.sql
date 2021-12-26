select t.range as raspon_kvadrature, count(*) as  broj_nekretnina
from ( 
  select case  
    when apartment_area <= 35 then '<35 m2'
    when apartment_area > 35 and apartment_area <= 50 then '35-50 m2'
    when apartment_area > 50 and apartment_area <= 65 then '50-65 m2'
    when apartment_area > 65 and apartment_area <= 80 then '65-80 m2'
    when apartment_area > 80 and apartment_area <= 95 then '80-95 m2'
    when apartment_area > 95 and apartment_area <= 110 then '95-110 m2'
    else '>111 m2' end as range
  from apartments
  where apartment_type = 1) t
group by t.range
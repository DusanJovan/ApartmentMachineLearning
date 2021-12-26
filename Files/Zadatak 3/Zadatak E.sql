

select t.range as raspon_kvadrature, count(*) as  broj_nekretnina, count(*) * 100.0 / (select count(*) from apartments where apartment_type = 1) as procenat
from ( 
  select case  
    when price < 50000 then '<50000'
    when price > 50000 and price <= 100000 then '50000-100000'
    when price > 100000 and price <= 150000 then '100000-150000'
    when price > 150000 and price <= 200000 then '150000-200000'
    else '>200000' end as range
  from apartments
  where apartment_type = 1) t
group by t.range
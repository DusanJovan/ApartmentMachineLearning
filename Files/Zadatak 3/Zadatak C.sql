select case when year_type = 1 then 'novogradnja' else 'starogradnja' end, count(*) from apartments group by year_type
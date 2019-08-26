
### linq 左连接 ###

	from a in list
    join i in newList on a equals i into temp
    from tt in temp.DefaultIfEmpty();
    select new {a, tt};

*** DefaultIfEmpty();

----------
since:8/26/2019 5:03:15 PM 
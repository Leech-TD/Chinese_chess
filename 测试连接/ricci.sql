#反引号’‘可以用来规避 关键字
#**********mysql 基本增删改查*********
SELECT * FROM `user`  WHERE NAME='林黛玉'
#net start mysql/net stop mysql
#->mysql -h 127.0.0.1 -P 3306 -u root -p root /*连接mysql*/
#显示所有数据库
SHOW DATABASES
#显示数据库创建语句
SHOW CREATE DATABASE  jmysql
#显示表字段
desc user
SHOW COLUMNS FROM runoob_tbl
#删除数据库
DROP DATABASE  jmysql
#备份数据库
mysqldump -u root -p -B jmysql >D:\\out.sql
#恢复数据库
source D:\\out.sql
#切换数据库
USE jmysql
#创建表
CREATE TABLE IF NOT EXISTS `runoob_tbl`(
   `runoob_id` INT UNSIGNED AUTO_INCREMENT,
   `runoob_title` VARCHAR(100) NOT NULL,
   `runoob_author` VARCHAR(40) NOT NULL,
   `submission_date` DATE,
   PRIMARY KEY ( `runoob_id` )
)ENGINE=InnoDB DEFAULT CHARSET=utf8;
#删除表
DROP TABLE `runoob_tbl`
DESC  runoob_tbl
#修改表
ALTER  TABLE runoob_tbl ADD `markdowm` VARCHAR(25) AFTER submission_date
ALTER  TABLE runoob_tbl MODIFY markdowm char(4);
ALTER  TABLE runoob_tbl MODIFY submission_date datetime;
ALTER  TABLE runoob_tbl CHANGE markdowm markdown char(4)
#insert
INSERT INTO runoob_tbl(runoob_title, runoob_author, submission_date,markdowm) VALUES ("学习 PHP", "菜鸟教程", NOW(),"注释")
#update
UPDATE runoob_tbl SET markdowm="新的注释" WHERE markdowm="注释"
#delete
#ORDER BY  asc|desc
SELECT * FROM runoob_tbl ORDER BY markdowm ASC;

#******聚合函数*******
SELECT COUNT(*) FROM user WHERE  name='林黛玉';
select avg(math) from user
SELECT SUM(math+history+english) AS score FROM user;
SELECT MAX(math) AS math_high_socre, MIN(math) AS math_low_socre FROM user;
select name,sum(math+history+english)as total from user group by name;
select * FROM runoob_tbl WHERE submission_date=crurent_date();
SELECT CURRENT_DATE FROM DUAL;

#******字符串函数********
SELECT CHARSET(name) FROM user
SELECT CONCAT(name,'do',job) from user
SELECT INSTR('chinese','ese') from DUAL
SELECT UCASE(runoob_title) FROM runoob_tbl
SELECT LCASE(runoob_title) FROM runoob_tbl
SELECT left('chinese',5) from DUAL
#（）占的字节数
SELECT LENGTH(name) FROM user
SELECT STRCMP('long','lon') FROM dual
SELECT name,REPLACE(job,'医生','公主')as after_replace FROM user
SELECT SUBSTRING(name,1,3) from user
SELECT LTRIM(name) from user where job='乞丐'
SELECT RTRIM('dual           ')from DUAL
SELECT TRIM('          dual           ')as '1' from DUAL

#******数值函数********
SELECT ABS(-100) FROM dual
SELECT BIN(8) from dual
SELECT HEX(10) FROM DUAL 
SELECT OCT(9) from DUAL
SELECT CEILING(1.1) from dual
SELECT CONV(16,16,2) from dual
SELECT FORMAT(7.44651919,4) FROM DUAL
SELECT LEAST(1,0.6,9) FROM DUAL
SELECT MOD(10, 3) FROM DUAL;
#[SEND]返回固定的
SELECT RAND(1) FROM DUAL;


#*******时间日期相关函数*******
SELECT CURRENT_DATE FROM DUAL
SELECT CURRENT_TIME from dual
SELECT CURRENT_TIMESTAMP FROM DUAL
SELECT NOW() from dual
SELECT DATE(NOW()) from dual
SELECT DATE_ADD(NOW(),1-01-01) from dual
#SECOND MINUTE HOUR DAY
SELECT * FROM runoob_tbl WHERE DATE_ADD(submission_date,INTERVAL 10 DAY)>NOW()
SELECT * FROM runoob_tbl WHERE DATE_SUB(NOW(),INTERVAL 10 MINUTE)>submission_date
SELECT DATEDIFF(NOW(),DATE_SUB(NOW(),INTERVAL 10 DAY)) AS DIFFDAYS FROM dual
# YEAR MONTH DAY DATE| (DATETIME)
SELECT YEAR(NOW()) FROM DUAL
SELECT MONTH('2022-3-7') FROM DUAL;
#UNIX_TIMESTAMP() 1970-01-01 00-00-00到现在的秒数
SELECT UNIX_TIMESTAMP()/(365*24*60*60) FROM DUAL
SELECT UNIX_TIMESTAMP() FROM DUAL
#FROM_UNIXTIME(unix_timestamp,format)
SELECT FROM_UNIXTIME(1646549113,'%Y-%m-%d %H:%i:%s') FROM DUAL

#加密和系统函数***********
SELECT user() from dual;
SELECT MD5('root') from dual
SELECT LENGTH(MD5('waipokuaile..')) FROM DUAL;
SELECT PASSWORD('root') FROM DUAL
#mysql使用password进行加密
#*81F5E21E35407D884A6CD4A731AEBFB6AF209E1B
SELECT * FROM mysql.`user`

#流程控制函数************
SELECT IF(TRUE,'expr2','expr3')FROM DUAL
SELECT IFNULL('NULL','expr2') FROM DUAL
SELECT name, IF(math is null,0.0,null)from user where name='傻逼';
SELECT name, IFNULL(math,0.0)from user ;
SELECT name,job, (SELECT CASE 
	WHEN job='医生' THEN 'kueen'
	else job		
END 
)FROM user;

#表查询增强****************
#SQL增加 HAVING 子句原因是，WHERE 关键字无法与聚合函数一起使用
SELECT name from user GROUP BY name having sum(english)>100
#like  _代表一个字符，%模糊
SELECT name FROM user where name LIKE '_逼%'
#分页查询
SELECT * FROM user LIMIT 0 ,2
#自连接自己插自己
SELECT wife.name AS wname,husband.name AS hname FROM user wife, user husband where wife.pal_id=husband.id;
#子查询(嵌入到其他sql的语句中的select)多行子查询
SELECT * FROM user WHERE name=(SELECT name FROM user WHERE name='林黛玉' AND english>89)
select name,job from user where name in(select name from user where name like '%玉')
#ALL, ANY
SELECT name,job FROM user WHERE english>ANY(SELECT english FROM user  where name='傻逼666' )


#表复制和去重
#自我复制
insert into runoob_tbl SELECT * from runoob_tbl
#结构及数据
create table runoob_tbl3 (SELECT * from runoob_tbl)
#结构
CREATE TABLE copy_table like runoob_tbl
SHOW CREATE TABLE copy_table
#union all不去重  union去重
select name from user where name like '%玉'
union all
select english from user where english>80
#统计重复数据
select count(*) as num ,name from user  group by name having num>1
#过滤重复1.distinct 2.group by
select distinct name from user
select name from user group by name


-- 创建 主表 my_class
CREATE TABLE my_class (
id INT(10) PRIMARY KEY , -- 班级编号
`name` VARCHAR(32) NOT NULL DEFAULT '')ENGINE=INNODB DEFAULT CHARSET=utf8; -- 创建 从表 my_stu
CREATE TABLE my_stu (
id INT PRIMARY KEY , -- 学生编号
`name` VARCHAR(32) NOT NULL DEFAULT '',
class_id INT , -- 学生所在班级的编号
-- 下面指定外键关系
FOREIGN KEY (class_id) REFERENCES my_class(id))ENGINE=INNODB DEFAULT CHARSET=utf8;

drop tables my_stu,my_class

-- 测试数据
INSERT INTO my_class
VALUES(100, 'java'), (200, 'web');
INSERT INTO my_class
VALUES(300, 'php');
SELECT * FROM my_class;
INSERT INTO my_stu
VALUES(1, 'tom', 100);
INSERT INTO my_stu
VALUES(2, 'jack', 200);
 
SELECT * FROM my_stu;


-- 测试check***********mysql5.7 目前还不支持 check ,只做语法校验，但不会生
CREATE TABLE t23 (
id INT PRIMARY KEY, `name` VARCHAR(32) , sex VARCHAR(6) CHECK (sex IN('man','woman')), sal DOUBLE CHECK ( sal > 1000 AND sal < 2000))
#任然可以插入
INSERT INTO t23
VALUES(2, 'jack', 'mid', 1)
#没有索引全表扫描，增加索引形成索引的数据结构（二叉树）
#索引 增加内存开销，对增删改变慢 查变快 select远大于增删改时
create table test(
 id int(25),
 content VARCHAR(100)
)
show index from test
show keys from test
create index normalindex on test(id)
drop index indexname on test
create unique index indexname on test(id)
alter table test add primary key indexname (id)

#**********事务和锁**************
#如果不开始事务，默认情况下，dml 操作是自动提交的，不能回滚
start transaction
savepoint a
insert into test values(5,'pig')
SAVEPOINT b
insert into test values(6,'dragon')
rollback to b
rollback to a
commit

#修改表引擎
alter table test  engine=innodb 
alter table user  engine=innodb 

show create table test
#查看当前会话隔离
select @@tx_isolation
#查看当前系统隔离级别
select @@global.tx_isolation
#设置当前会话级别
set session transaction isolation level repeatable read
#设置系统隔离级别
set global transaction isolation level repeatable read

show engines
#后期加外键
alter table test add constraint c_name foreign key (pal_id) references user(id)

#临时表临时表只在当前连接可见，当关闭连接时，Mysql会自动删除表并释放所有空间innodb
create temporary  table test01 (
  id int primary key,
	name varchar(25)
)
#ENGINE=MEMORY,关闭连接结构还存在，数据消失
insert into test01 VALUES (1,'psvavav');
SELECT * from test02
show create table test02
drop tables test01,test02
create  table test02 (
  id int primary key,
	name varchar(25)
)ENGINE=MEMORY
insert into test02 VALUES (1,'psvavav');

#视图，视图的数据变化会影响到基表，基表的数据变化也会影响到视图[insert update delete ]
create view myview as SELECT id,`name`,job from `user`;
SELECT*from myview
desc myview

#用户管理
create user `test`@`localhost` identified by 'test'
select * from mysql.user
GRANT SELECT,UPDATE,DELETE ON jmysql.`user` TO `test`@`localhost`
REVOKE UPDATE,DELETE ON jmysql.`user` FROM `test`@`localhost`
drop user `test`@`localhost`

#********SQL注入*************
CREATE TABLE admin ( -- 管理员表
NAME VARCHAR(32) NOT NULL UNIQUE, pwd VARCHAR(32) NOT NULL DEFAULT '') CHARACTER SET utf8; -- 添加数据

INSERT INTO admin VALUES('tom','123');
INSERT INTO admin VALUES('Jack','456');
INSERT INTO admin VALUES('Bob','789');


SELECT * FROM admin

SELECT *
FROM admin
WHERE NAME = '1' OR' AND pwd = 'OR '1'


select name,pwd from admin where name='tom' and pwd='123';
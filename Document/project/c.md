
### q:mysql在使用了orderBy后查询缓慢 ###

查询语句：

	SELECT	*
	FROM 
	(SELECT
	`Extent1`.`OrderID`, 
	`Extent1`.`OrderNo`, 
	`Extent1`.`TBOrderID`, 
	`Extent1`.`CustomerID`, 
	`Extent1`.`state`, 
	`Extent1`.`IsPay`, 
	`Extent1`.`isUrgent`, 
	`Extent1`.`CreateUserNikeName`, 
	`Extent1`.`CreateTime`, 
	`Extent1`.`IsNeedCustomerService`, 
	`Extent1`.`IsSentEmail`, 
	`Extent1`.`Remark`, 
	`Extent1`.`TBNum`, 
	`Extent1`.`CustomerName`, 
	`Extent1`.`CustomerEnname`, 
	`Extent1`.`Tel`, 
	`Extent1`.`Email`, 
	`Extent1`.`AfterSalesNickName`, 
	`Extent1`.`NotAfterSalesNickName`, 
	`Extent2`.`ServiceCode`, 
	`Extent2`.`cnItemName`, 
	`Extent2`.`SupplierCode`, 
	`Extent2`.`AdultNum`, 
	`Extent2`.`ChildNum`, 
	`Extent2`.`INFNum`, 
	`Extent2`.`RoomNum`, 
	`Extent2`.`RightNum`, 
	`Extent2`.`TravelDate`, 
	`Extent2`.`GroupNo`, 
	`Extent2`.`TrafficSurcharge`, 
	`Extent2`.`ServiceTypeID`, 
	`Extent3`.`TBID`, 
	`Extent3`.`OrderSourseID`, 
	`Extent4`.`CurrencyNo`, 
	`Extent6`.`OrderSourseName`, 
		CASE 
			WHEN (`Extent5`.`ServiceItemSupplierCodeID` IS NOT NULL) 
				THEN (`Extent5`.`EnableApi`)  
			ELSE (0) 
		END AS `C1`
		FROM `Orders` AS `Extent1` 
			INNER JOIN `ServiceItemHistories` AS `Extent2` ON `Extent1`.`OrderID` = `Extent2`.`OrderID` 
			INNER JOIN `TBOrders` AS `Extent3` ON `Extent1`.`TBOrderID` = `Extent3`.`TBOrderID` 
			INNER JOIN `Currencies` AS `Extent4` ON `Extent2`.`TrafficCurrencyID` = `Extent4`.`CurrencyID` 
			LEFT OUTER JOIN `ServiceItemSupplierCodes` AS `Extent5` ON (`Extent2`.`SupplierID` = `Extent5`.`SupplierID`) AND (`Extent2`.`ServiceItemID` = `Extent5`.`ServiceItemID`) 
			INNER JOIN `OrderSourses` AS `Extent6` ON `Extent3`.`OrderSourseID` = `Extent6`.`OrderSourseID`
	 	WHERE `Extent1`.`IsHide` != 1
	 
	 ) AS `Project1`
	 
	 ORDER BY 
	`Project1`.`OrderID` DESC LIMIT 0,50

[https://blog.csdn.net/hehexiaoxia/article/details/54585175](https://blog.csdn.net/hehexiaoxia/article/details/54585175 "帮助文章")

通过缩小查询，将最终sql锁定在了：

	SELECT *
		FROM `Orders` AS `Extent1` 
		INNER JOIN `ServiceItemHistories` AS `Extent2` ON `Extent1`.`OrderID` = `Extent2`.`OrderID`
		 INNER JOIN `Currencies` AS `Extent4` ON `Extent2`.`TrafficCurrencyID` = `Extent4`.`CurrencyID`
	 	WHERE `Extent1`.`IsHide` != 1
	 	
	 ORDER BY Extent1.OrderID DESC
	LIMIT 0,50 ;

![结果图](https://i.ibb.co/zHwWw4k/explain.png)

[https://www.cnblogs.com/xuanzhi201111/p/4175635.html](https://www.cnblogs.com/xuanzhi201111/p/4175635.html "MySql Explain 详解")

通过对比可知，加上order时多出了：

> Using temporary：表示MySQL需要使用临时表来存储结果集，常见于排序和分组查询
> 
> Using filesort：MySQL中无法利用索引完成的排序操作称为“文件排序”

solution:使用`Extent2`.`OrderID`作为排序字段【后续再deep...】

### count 使用 left join on 多个条件时查询缓慢 ###

sql:

	SELECT COUNT(1)
	FROM `Orders` AS `Extent1`
	INNER JOIN `ServiceItemHistories` AS `Extent2` ON `Extent1`.`OrderID` = `Extent2`.`OrderID`
	LEFT OUTER
	JOIN `ServiceItemSupplierCodes` AS `Extent4` ON
			`Extent2`.`ServiceItemID` = `Extent4`.`ServiceItemID` 
			AND
			`Extent2`.`SupplierID` = `Extent4`.`SupplierID`
	WHERE `Extent1`.`IsHide` != 1

key :
	`Extent2`.`ServiceItemID` = `Extent4`.`ServiceItemID` 
	AND
	`Extent2`.`SupplierID` = `Extent4`.`SupplierID`

仅存在一个条件时速度正常，多个时缓慢..

solution:由于只使用一个不影响查询结果故使用
	


----------
since:9/2/2019 1:54:14 PM 
 
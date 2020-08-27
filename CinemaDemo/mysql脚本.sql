/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 50717
Source Host           : 127.0.0.1:3306
Source Database       : mydatabase

Target Server Type    : MYSQL
Target Server Version : 50717
File Encoding         : 65001

Date: 2020-08-27 15:07:16
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for Cinema
-- ----------------------------
DROP TABLE IF EXISTS `Cinema`;
CREATE TABLE `Cinema` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `Grade` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for CinemaTicket
-- ----------------------------
DROP TABLE IF EXISTS `CinemaTicket`;
CREATE TABLE `CinemaTicket` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CinemaId` int(11) DEFAULT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `Star` varchar(255) DEFAULT NULL,
  `ReleaseTime` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
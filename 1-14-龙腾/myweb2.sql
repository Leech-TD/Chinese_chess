/*
 Navicat Premium Data Transfer

 Source Server         : new
 Source Server Type    : MySQL
 Source Server Version : 50726
 Source Host           : localhost:3306
 Source Schema         : myweb

 Target Server Type    : MySQL
 Target Server Version : 50726
 File Encoding         : 65001

 Date: 14/01/2021 15:54:13
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for book
-- ----------------------------
DROP TABLE IF EXISTS `book`;
CREATE TABLE `book`  (
  `book_id` int(11) NOT NULL AUTO_INCREMENT,
  `type_id` int(11) NULL DEFAULT NULL,
  `book_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`book_id`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 8 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of book
-- ----------------------------
INSERT INTO `book` VALUES (1, 1, '计算机导论');
INSERT INTO `book` VALUES (2, 2, 'C++');

-- ----------------------------
-- Table structure for book_type
-- ----------------------------
DROP TABLE IF EXISTS `book_type`;
CREATE TABLE `book_type`  (
  `type_id` int(11) NOT NULL AUTO_INCREMENT,
  `type_name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`type_id`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 4 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of book_type
-- ----------------------------
INSERT INTO `book_type` VALUES (1, '计算机基础');
INSERT INTO `book_type` VALUES (2, 'C++程序');

-- ----------------------------
-- Table structure for cart
-- ----------------------------
DROP TABLE IF EXISTS `cart`;
CREATE TABLE `cart`  (
  `cart_id` int(255) UNSIGNED NOT NULL AUTO_INCREMENT,
  `uid` int(11) NULL DEFAULT NULL COMMENT '用户id',
  `gid` int(11) NULL DEFAULT NULL COMMENT '商品id',
  PRIMARY KEY (`cart_id`) USING BTREE,
  INDEX `商品id`(`gid`) USING BTREE,
  INDEX `uid`(`uid`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 10 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Fixed;

-- ----------------------------
-- Records of cart
-- ----------------------------
INSERT INTO `cart` VALUES (1, 100, 2);
INSERT INTO `cart` VALUES (2, 100, 3);
INSERT INTO `cart` VALUES (3, 100, 4);
INSERT INTO `cart` VALUES (4, 101, 5);
INSERT INTO `cart` VALUES (5, 101, 6);
INSERT INTO `cart` VALUES (6, 1, 2);
INSERT INTO `cart` VALUES (7, 1, 3);
INSERT INTO `cart` VALUES (8, 1, 4);

-- ----------------------------
-- Table structure for config
-- ----------------------------
DROP TABLE IF EXISTS `config`;
CREATE TABLE `config`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '配置的key键名',
  `value` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '配置的val值',
  `type` varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '配置分组',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 7 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of config
-- ----------------------------
INSERT INTO `config` VALUES (1, 'smtp_server', 'smtp.qq.com111', 'smtp');
INSERT INTO `config` VALUES (2, 'smtp_port', '465', 'smtp');
INSERT INTO `config` VALUES (3, 'smtp_user', '331549185@qq.com', 'smtp');
INSERT INTO `config` VALUES (4, 'smtp_pwd', '12017700', 'smtp');
INSERT INTO `config` VALUES (5, 'regis_smtp_enable', '1', 'smtp');
INSERT INTO `config` VALUES (6, 'email_id', '11', 'smtp');

-- ----------------------------
-- Table structure for goods
-- ----------------------------
DROP TABLE IF EXISTS `goods`;
CREATE TABLE `goods`  (
  `goods_id` int(255) NOT NULL AUTO_INCREMENT,
  `type_id` int(11) NULL DEFAULT NULL COMMENT '类型',
  `goods_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '名称',
  `user_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '发布用户',
  `price` decimal(10, 2) NULL DEFAULT NULL COMMENT '价格',
  `status` int(255) NULL DEFAULT NULL COMMENT '是否下架',
  `Modify` date NULL DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`goods_id`) USING BTREE,
  INDEX `类型`(`type_id`) USING BTREE,
  INDEX `用户`(`user_id`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 10 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of goods
-- ----------------------------
INSERT INTO `goods` VALUES (2, 1, '衣架', '100', 3.78, 2, '2021-01-09');
INSERT INTO `goods` VALUES (3, 1, '箱子', '100', 7.88, 2, '2021-01-02');
INSERT INTO `goods` VALUES (4, 2, 'iPhone11', '101', 2.33, 1, '2020-12-28');
INSERT INTO `goods` VALUES (5, 2, '相机', '102', 78.99, 1, '2020-10-26');
INSERT INTO `goods` VALUES (6, 3, '花露水', '1', 18.08, 1, '2020-12-31');
INSERT INTO `goods` VALUES (7, 3, '沐浴露', '1', 56.11, 1, '2021-01-12');

-- ----------------------------
-- Table structure for goods_type
-- ----------------------------
DROP TABLE IF EXISTS `goods_type`;
CREATE TABLE `goods_type`  (
  `type_id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT,
  `type_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`type_id`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 9 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of goods_type
-- ----------------------------
INSERT INTO `goods_type` VALUES (1, '生活百货');
INSERT INTO `goods_type` VALUES (2, '手机数码');
INSERT INTO `goods_type` VALUES (3, '美妆护肤');
INSERT INTO `goods_type` VALUES (4, '书籍闲置');
INSERT INTO `goods_type` VALUES (5, '服饰配件');
INSERT INTO `goods_type` VALUES (6, '其他闲置');

-- ----------------------------
-- Table structure for message
-- ----------------------------
DROP TABLE IF EXISTS `message`;
CREATE TABLE `message`  (
  `message_id` int(11) NOT NULL AUTO_INCREMENT,
  `gid` int(11) NULL DEFAULT NULL COMMENT '商品id',
  `content` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '留言内容',
  `uid` int(11) NULL DEFAULT NULL COMMENT '评论用户id',
  PRIMARY KEY (`message_id`) USING BTREE,
  INDEX `gid`(`gid`) USING BTREE,
  INDEX `uid`(`uid`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 7 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of message
-- ----------------------------
INSERT INTO `message` VALUES (1, 1, '可以便宜点吗？', 102);
INSERT INTO `message` VALUES (2, 1, '真心想要了留给我。。。。', 103);
INSERT INTO `message` VALUES (3, 1, '可以面交付吗？', 101);
INSERT INTO `message` VALUES (4, 6, '发顺丰给我吧', 100);
INSERT INTO `message` VALUES (5, 7, '有没有发票的？', 102);
INSERT INTO `message` VALUES (6, 2, '我想和你聊聊啊！', 101);

-- ----------------------------
-- Table structure for news
-- ----------------------------
DROP TABLE IF EXISTS `news`;
CREATE TABLE `news`  (
  `news_id` int(11) NOT NULL AUTO_INCREMENT,
  `type_id` int(11) NULL DEFAULT NULL,
  `user_id` int(11) NULL DEFAULT NULL,
  `title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `content` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `create_time` int(11) NULL DEFAULT NULL,
  `status` tinyint(2) NULL DEFAULT 1 COMMENT '1 正常 2至顶  0 隐藏',
  `views` int(11) NULL DEFAULT 0 COMMENT '阅读次数',
  PRIMARY KEY (`news_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 96 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of news
-- ----------------------------
INSERT INTO `news` VALUES (87, 1, NULL, '社会新闻1', '<p>asdfasdfasfd</p><p>asdfasdfasfd</p><p style=\"line-height: 16px;\"><img src=\"http://mytp.com/static/ueditor/dialogs/attachment/fileTypeImages/icon_doc.gif\"/><a style=\"font-size:12px; color:#0066cc;\" href=\"/uploads/20200329/1585489452524431.docx\" title=\"2016版毕业要求.docx\">2016版毕业要求.docx</a></p><p><br/></p>', 1586414643, 1, 0);
INSERT INTO `news` VALUES (88, 3, NULL, '经济新闻1', '<p>asdf00</p><p>asdfasdfasdf</p><p>asdfasdfasdf</p>', 1586414594, 2, 0);
INSERT INTO `news` VALUES (89, 3, NULL, '经济新闻1', '<p>asdfasdfasfd1</p><p>asdfasdfasfd</p><p style=\"line-height: 16px;\"><img src=\"http://mytp.com/static/ueditor/dialogs/attachment/fileTypeImages/icon_doc.gif\"/><a style=\"font-size:12px; color:#0066cc;\" href=\"/uploads/20200329/1585489452524431.docx\" title=\"2016版毕业要求.docx\">2016版毕业要求.docx</a></p><p><br/></p>', 1586414632, 0, 0);
INSERT INTO `news` VALUES (93, 2, NULL, '体育新闻1', '<p>99</p>', 1588490378, 1, 0);
INSERT INTO `news` VALUES (94, 1, NULL, 'web网页课设', '<p>大家好~</p>', 1610467200, 2, 0);
INSERT INTO `news` VALUES (95, 3, NULL, '11111111', '<p>1111111111111111111111111</p><p>1111111111111111111111111</p><p>1111111111111111111111111</p><p>1111111111111111111111111</p>', 1610547356, 1, 0);

-- ----------------------------
-- Table structure for news_type
-- ----------------------------
DROP TABLE IF EXISTS `news_type`;
CREATE TABLE `news_type`  (
  `type_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `type_name` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`type_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of news_type
-- ----------------------------
INSERT INTO `news_type` VALUES (1, '社会新闻');
INSERT INTO `news_type` VALUES (2, '体育新闻');
INSERT INTO `news_type` VALUES (3, '经济新闻');

-- ----------------------------
-- Table structure for order
-- ----------------------------
DROP TABLE IF EXISTS `order`;
CREATE TABLE `order`  (
  `order_id` int(11) NOT NULL AUTO_INCREMENT COMMENT '订单编号',
  `uid0` int(11) NULL DEFAULT NULL COMMENT '买家',
  `goods_id` int(11) NULL DEFAULT NULL COMMENT '商品id',
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '订单备注',
  `modify` datetime(0) NULL DEFAULT NULL COMMENT '订单时间',
  `type_id` int(11) NULL DEFAULT NULL COMMENT '状态',
  PRIMARY KEY (`order_id`) USING BTREE,
  INDEX `type_id`(`type_id`) USING BTREE,
  INDEX `uid0`(`uid0`) USING BTREE,
  INDEX `goods_id`(`goods_id`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 89898993 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of order
-- ----------------------------
INSERT INTO `order` VALUES (89898990, 102, 2, '韵达快递', '2021-01-02 22:10:32', 1);
INSERT INTO `order` VALUES (89898991, 100, 7, '中通快递', '2021-01-12 22:41:24', 2);
INSERT INTO `order` VALUES (89898992, 1, 3, '顺丰快递', '2021-01-04 23:00:02', 2);

-- ----------------------------
-- Table structure for order_type
-- ----------------------------
DROP TABLE IF EXISTS `order_type`;
CREATE TABLE `order_type`  (
  `type_id` int(11) NOT NULL AUTO_INCREMENT,
  `type_name` varchar(11) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`type_id`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 5 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of order_type
-- ----------------------------
INSERT INTO `order_type` VALUES (1, '等待卖家发货');
INSERT INTO `order_type` VALUES (2, '派送中...');
INSERT INTO `order_type` VALUES (3, '等待买家签收');
INSERT INTO `order_type` VALUES (4, '已经完成');

-- ----------------------------
-- Table structure for sys_menu
-- ----------------------------
DROP TABLE IF EXISTS `sys_menu`;
CREATE TABLE `sys_menu`  (
  `menu_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `url` varchar(80) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `name` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `icon` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '图标',
  `parent_id` int(5) NOT NULL DEFAULT 0 COMMENT '父栏目ID',
  `sort` int(11) NULL DEFAULT 0 COMMENT '排序',
  `visible` tinyint(1) NULL DEFAULT 1 COMMENT '是否可见',
  `open` tinyint(1) NULL DEFAULT 1 COMMENT '1',
  PRIMARY KEY (`menu_id`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 42 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sys_menu
-- ----------------------------
INSERT INTO `sys_menu` VALUES (1, '', '系统功能', 'layui-icon-set', 0, 1, 1, 1);
INSERT INTO `sys_menu` VALUES (2, '/admin/menu/index', '菜单管理', '', 1, 1, 1, 1);
INSERT INTO `sys_menu` VALUES (3, '/admin/role/index', '角色管理', '', 1, 3, 1, 1);
INSERT INTO `sys_menu` VALUES (4, '/admin/user/index', '用户管理', '', 1, 2, 1, 1);
INSERT INTO `sys_menu` VALUES (5, '/admin/news/index', '新闻列表', '', 6, 1, 1, 1);
INSERT INTO `sys_menu` VALUES (6, '', '新闻管理', 'layui-icon-date', 0, 1, 1, 1);
INSERT INTO `sys_menu` VALUES (7, '/admin/news_type', '新闻类别', '', 6, 2, 1, 1);
INSERT INTO `sys_menu` VALUES (17, '', '图书管理', 'layui-icon-heart-fill', 0, 1, 1, 1);
INSERT INTO `sys_menu` VALUES (18, '/teach/books/index', '图书列表', '', 17, 1, 1, 1);
INSERT INTO `sys_menu` VALUES (19, '/teach/books/type', '图书类别', '', 17, 2, 1, 1);
INSERT INTO `sys_menu` VALUES (20, '/admin/goods_type', '商品分类管理', '', 28, 2, 1, 1);
INSERT INTO `sys_menu` VALUES (21, '/admin/goods/index', '商品列表', '', 28, 1, 1, 1);
INSERT INTO `sys_menu` VALUES (24, '/admin/selling/index', '我卖出的', '', 33, 2, 1, 1);
INSERT INTO `sys_menu` VALUES (25, '/admin/buying/index', '我买到的', '', 33, 3, 1, 1);
INSERT INTO `sys_menu` VALUES (33, '', '我的订单', 'layui-icon-form', 0, 1, 1, 1);
INSERT INTO `sys_menu` VALUES (36, '/admin/order_type', '订单类别', '', 29, 2, 1, 1);
INSERT INTO `sys_menu` VALUES (28, '', '商品管理', 'layui-icon-gift', 0, 1, 1, 1);
INSERT INTO `sys_menu` VALUES (29, '', '订单管理', 'layui-icon-form', 0, 1, 1, 1);
INSERT INTO `sys_menu` VALUES (30, '/admin/order/index', '订单列表', '', 29, 1, 1, 1);
INSERT INTO `sys_menu` VALUES (31, '/admin/cart/index', '购物车', 'layui-icon-cart-simple', 0, 1, 1, 1);
INSERT INTO `sys_menu` VALUES (32, '/admin/talk/index', '消息', 'layui-icon-email', 0, 1, 1, 1);
INSERT INTO `sys_menu` VALUES (41, '/admin/trade/index', '购物大厅', '', 0, 1, 1, 1);

-- ----------------------------
-- Table structure for sys_role
-- ----------------------------
DROP TABLE IF EXISTS `sys_role`;
CREATE TABLE `sys_role`  (
  `role_id` smallint(6) UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `role_key` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `menus` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`role_id`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 11 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sys_role
-- ----------------------------
INSERT INTO `sys_role` VALUES (1, '超级管理员', 'admin', '1,2,3,4,28,20,21,29,36,30,31,32,41,');
INSERT INTO `sys_role` VALUES (2, '员工', 'work', '1,4,28,20,21,29,30,');
INSERT INTO `sys_role` VALUES (3, '用户', 'user', '33,24,25,31,32,41,');

-- ----------------------------
-- Table structure for sys_user
-- ----------------------------
DROP TABLE IF EXISTS `sys_user`;
CREATE TABLE `sys_user`  (
  `user_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `username` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '用户名',
  `password` varchar(70) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '密码',
  `role_id` mediumint(8) NULL DEFAULT NULL COMMENT '分组ID',
  `email` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '邮箱',
  `realname` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '真实姓名',
  `gender` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '' COMMENT '性别',
  `phone` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '电话号码',
  `login_time` int(11) NULL DEFAULT NULL COMMENT '最后登录时间',
  `status` tinyint(2) NULL DEFAULT 1 COMMENT '状态',
  `avatar` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '头像',
  `online` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`user_id`) USING BTREE,
  INDEX `user_username`(`username`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 105 CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '用户表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of sys_user
-- ----------------------------
INSERT INTO `sys_user` VALUES (1, '1', 'c4ca4238a0b923820dcc509a6f75849b', 1, '4', '超管', '女', '10086', 1610606978, 1, NULL, 0);
INSERT INTO `sys_user` VALUES (58, 'zh', 'c4ca4238a0b923820dcc509a6f75849b', 2, '1', '曾辉', '男', '110', 1610474140, 1, '/uploads/20201124/c764388e79ebea5ec136aa3afb29ae5e.jpg', 0);
INSERT INTO `sys_user` VALUES (2, '2', 'c4ca4238a0b923820dcc509a6f75849b', 2, NULL, '720', '', '13456184266', 1610471051, 1, NULL, 1);
INSERT INTO `sys_user` VALUES (100, 'zhao', 'c4ca4238a0b923820dcc509a6f75849b', 3, NULL, '赵云', '男', '13838384384', 1610609915, 1, NULL, 1);
INSERT INTO `sys_user` VALUES (101, 'li', 'c4ca4238a0b923820dcc509a6f75849b', 3, NULL, '公孙离', '女', '12234242452', NULL, 1, NULL, NULL);

SET FOREIGN_KEY_CHECKS = 1;

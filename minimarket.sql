-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               8.0.40 - MySQL Community Server - GPL
-- Server OS:                    Win64
-- HeidiSQL Version:             12.8.0.6908
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for minimarket
DROP DATABASE IF EXISTS `minimarket`;
CREATE DATABASE IF NOT EXISTS `minimarket` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `minimarket`;

-- Dumping structure for table minimarket.transaksi
DROP TABLE IF EXISTS `transaksi`;
CREATE TABLE IF NOT EXISTS `transaksi` (
  `id_transaksi` int NOT NULL AUTO_INCREMENT,
  `no_transaksi` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `id_kasir` int NOT NULL,
  `waktu` datetime NOT NULL,
  `bayar` bigint NOT NULL,
  `grand_total` bigint NOT NULL,
  `kembalian` bigint NOT NULL,
  `status` enum('pending','active','void','done','retur') COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`id_transaksi`)
) ENGINE=InnoDB AUTO_INCREMENT=101 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table minimarket.transaksi: ~4 rows (approximately)
INSERT IGNORE INTO `transaksi` (`id_transaksi`, `no_transaksi`, `id_kasir`, `waktu`, `bayar`, `grand_total`, `kembalian`, `status`) VALUES
	(89, '202411112111201', 1, '2024-11-11 21:11:20', 70000, 2000, 19600, 'retur'),
	(90, '202411112112091', 1, '2024-11-11 21:12:09', 0, 0, 0, 'void'),
	(91, '202411151853091', 1, '2024-11-15 18:53:09', 40000, 18200, 12700, 'retur'),
	(92, '202411151853381', 1, '2024-11-15 18:53:38', 0, 0, 0, 'void'),
	(93, '202411170537061', 1, '2024-11-17 05:37:06', 0, 0, 0, 'void'),
	(94, '202411170539231', 1, '2024-11-17 05:39:23', 0, 0, 0, 'void'),
	(95, '202411170600521', 1, '2024-11-17 06:00:52', 0, 0, 0, 'void'),
	(96, '202411170604561', 1, '2024-11-17 06:04:56', 0, 0, 0, 'void'),
	(97, '202411170722051', 1, '2024-11-17 07:22:05', 0, 0, 0, 'void'),
	(98, '202411170731041', 1, '2024-11-17 07:31:04', 0, 0, 0, 'void'),
	(99, '202411170756051', 1, '2024-11-17 07:56:05', 0, 0, 0, 'void'),
	(100, '202411170758391', 1, '2024-11-17 07:58:39', 0, 0, 0, 'active');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;

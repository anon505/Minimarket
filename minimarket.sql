-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 05, 2024 at 05:25 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `minimarket`
--

-- --------------------------------------------------------

--
-- Table structure for table `barang`
--

CREATE TABLE `barang` (
  `id_barang` int(11) NOT NULL,
  `id_suplier` int(11) NOT NULL,
  `id_satuan` int(11) NOT NULL,
  `barcode` varchar(254) NOT NULL,
  `nama_barang` varchar(50) NOT NULL,
  `harga_beli` int(100) NOT NULL,
  `ppn` float NOT NULL,
  `discount` float NOT NULL,
  `harga_beli_netto` int(11) NOT NULL,
  `stok_display` int(30) NOT NULL,
  `stok_gudang` int(30) NOT NULL,
  `harga_jual1` int(11) NOT NULL,
  `harga_jual2` int(11) NOT NULL,
  `harga_jual3` int(11) NOT NULL,
  `harga_jual4` int(11) NOT NULL,
  `qty2` int(11) NOT NULL,
  `qty3` int(11) NOT NULL,
  `qty4` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `barang`
--

INSERT INTO `barang` (`id_barang`, `id_suplier`, `id_satuan`, `barcode`, `nama_barang`, `harga_beli`, `ppn`, `discount`, `harga_beli_netto`, `stok_display`, `stok_gudang`, `harga_jual1`, `harga_jual2`, `harga_jual3`, `harga_jual4`, `qty2`, `qty3`, `qty4`) VALUES
(1, 2, 1, '8992696407688', 'Nestle 700g', 2500, 11, 0, 2775, 58, 57, 3386, 3372, 3316, 3191, 3, 6, 9),
(2, 2, 1, '896867700326', 'Le Minerale', 2000, 11, 0, 2220, 28, 61, 2600, 2300, 2270, 2264, 3, 8, 12),
(3, 3, 1, '7237844127560', 'Pempers Sensi', 3000, 0, 0, 3000, 27, 50, 3550, 3530, 3520, 3510, 5, 10, 15),
(4, 2, 1, '8992112011017', 'Cerebrovot', 4000, 0, 0, 4000, 12, 80, 4500, 4400, 4300, 4200, 2, 6, 10),
(5, 4, 1, '8886008101053', 'Aqua Sedang', 5000, 0, 0, 5000, 11, 90, 5900, 5700, 5600, 5500, 10, 20, 30);

-- --------------------------------------------------------

--
-- Stand-in structure for view `ds_markup`
-- (See below for the actual view)
--
CREATE TABLE `ds_markup` (
`id_pembelian` int(11)
,`no_faktur` varchar(254)
,`tgl_faktur` datetime
,`id_barang` int(11)
,`barcode` varchar(254)
,`nama_barang` varchar(50)
,`pembelian_detail.qty` int(11)
,`pembelian_detail.price` int(11)
,`pembelian_detail.ppn` float
,`pembelian_detail.discount` float
,`pembelian_detail.price_netto` int(11)
,`harga_satuan` int(11)
,`profit1` decimal(17,2)
,`qty2` int(11)
,`harga_qty2` int(11)
,`profit2` decimal(17,2)
,`qty3` int(11)
,`harga_qty3` int(11)
,`profit3` decimal(17,2)
,`qty4` int(11)
,`harga_qty4` int(11)
,`profit4` decimal(17,2)
,`status_pembelian` enum('temp','saved','mark_up')
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `ds_report_expiry`
-- (See below for the actual view)
--
CREATE TABLE `ds_report_expiry` (
`id_barang` int(11)
,`no_faktur` varchar(254)
,`tgl_faktur` datetime
,`expiry` date
,`lama_jatuh_tempo` int(11)
,`kode_suplier` varchar(100)
,`nama_suplier` varchar(30)
,`barcode` varchar(254)
,`nama_barang` varchar(50)
,`qty` int(11)
,`expire_in` int(7)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `ds_report_penjualan`
-- (See below for the actual view)
--
CREATE TABLE `ds_report_penjualan` (
`id_transaksi` int(11)
,`waktu` datetime
,`kode_transaksi` varchar(30)
,`id_kasir` int(11)
,`bayar` bigint(20)
,`grand_total` bigint(20)
,`kembalian` bigint(20)
,`status` enum('pending','active','void','done','retur')
,`id_transaksi_detail` int(11)
,`barcode` varchar(254)
,`nama_barang` varchar(50)
,`qty` int(30)
,`harga_beli` int(11)
,`harga_jual` int(11)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `ds_transaksi_pembelian`
-- (See below for the actual view)
--
CREATE TABLE `ds_transaksi_pembelian` (
`id_pembelian_detail` int(11)
,`id_pembelian` int(11)
,`no_faktur` varchar(254)
,`id_barang` int(11)
,`barcode` varchar(254)
,`nama_barang` varchar(50)
,`stok` bigint(31)
,`qty` int(11)
,`harga` int(11)
,`harga_lama` int(100)
,`ppn` float
,`ppn_lama` float
,`discount` float
,`discount_lama` float
,`harga_netto` int(11)
,`harga_netto_lama` int(11)
,`total` bigint(21)
,`expiry` date
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `ds_transaksi_penjualan`
-- (See below for the actual view)
--
CREATE TABLE `ds_transaksi_penjualan` (
`id_transaksi_detail` int(11)
,`id_transaksi` int(11)
,`barcode` varchar(254)
,`nama_barang` varchar(50)
,`harga` int(11)
,`qty` int(30)
,`jumlah` bigint(40)
,`stok` bigint(31)
,`updated_at` datetime
);

-- --------------------------------------------------------

--
-- Table structure for table `kasir`
--

CREATE TABLE `kasir` (
  `id_kasir` int(11) NOT NULL,
  `nama_kasir` varchar(30) NOT NULL,
  `password` varchar(30) NOT NULL,
  `alamat` varchar(100) NOT NULL,
  `type` int(11) NOT NULL COMMENT '1 superadmin, 2 admin, 3 kasir',
  `status` char(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `kasir`
--

INSERT INTO `kasir` (`id_kasir`, `nama_kasir`, `password`, `alamat`, `type`, `status`) VALUES
(1, 'Umam', '1', 'Sumenep', 1, 'Aktif'),
(2, 'Fajri', '2', 'Sumenep', 2, 'Aktif'),
(3, 'delan', '3', 'dsds', 3, 'Aktif');

-- --------------------------------------------------------

--
-- Table structure for table `mutasi`
--

CREATE TABLE `mutasi` (
  `id_mutasi` int(11) NOT NULL,
  `id_reff` int(11) DEFAULT NULL,
  `type` enum('penjualan','pembelian','hutang','lainnya') NOT NULL,
  `deskripsi` text NOT NULL,
  `status` enum('debit','credit') NOT NULL,
  `nominal` int(11) NOT NULL,
  `created_at` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `mutasi`
--

INSERT INTO `mutasi` (`id_mutasi`, `id_reff`, `type`, `deskripsi`, `status`, `nominal`, `created_at`) VALUES
(3, 15, 'pembelian', 'update PEMBELIAN secara TUNAI dengan faktur: 223344', 'debit', 8325, '2024-06-05 21:03:55'),
(4, 50, 'penjualan', 'PENJUALAN pada waktu: 05/06/2024 21:46:10', 'credit', 3386, '2024-06-05 21:48:23'),
(5, 51, 'penjualan', 'RETUR PENJUALAN pada waktu: 05/06/2024 21:48:23', 'debit', -3386, '2024-06-05 21:51:33'),
(6, 53, 'penjualan', 'PENJUALAN pada waktu: 05/06/2024 21:51:33', 'credit', 6772, '2024-06-05 21:53:28');

-- --------------------------------------------------------

--
-- Table structure for table `obrolan`
--

CREATE TABLE `obrolan` (
  `pesan` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `pembelian`
--

CREATE TABLE `pembelian` (
  `id_pembelian` int(11) NOT NULL,
  `no_faktur` varchar(254) NOT NULL,
  `tgl_faktur` datetime NOT NULL,
  `id_supplier` int(11) NOT NULL,
  `id_kasir` int(11) NOT NULL,
  `grand_total` int(30) NOT NULL,
  `metode_pembayaran` enum('tunai','konsinyasi','kredit') NOT NULL,
  `lama_jatuh_tempo` int(11) NOT NULL COMMENT 'lama jatuh tempo(hari) berdasarkan tgl faktur',
  `status` enum('temp','saved','mark_up') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `pembelian`
--

INSERT INTO `pembelian` (`id_pembelian`, `no_faktur`, `tgl_faktur`, `id_supplier`, `id_kasir`, `grand_total`, `metode_pembayaran`, `lama_jatuh_tempo`, `status`) VALUES
(14, '112233', '2024-06-04 05:55:34', 1, 1, 2775, 'tunai', 0, 'saved'),
(15, '223344', '2024-06-05 20:55:32', 1, 1, 8325, 'tunai', 0, 'saved'),
(16, '', '2024-06-05 20:59:01', 1, 1, 0, '', 0, 'temp');

-- --------------------------------------------------------

--
-- Table structure for table `pembelian_detail`
--

CREATE TABLE `pembelian_detail` (
  `id_pembelian_detail` int(11) NOT NULL,
  `id_pembelian` int(11) NOT NULL,
  `id_barang` int(11) NOT NULL,
  `qty` int(11) NOT NULL,
  `price` int(11) NOT NULL,
  `ppn` float NOT NULL,
  `discount` float NOT NULL,
  `price_netto` int(11) NOT NULL,
  `expiry` date DEFAULT NULL,
  `qty_return` int(11) NOT NULL,
  `status_return` enum('return','active') NOT NULL DEFAULT 'active'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `pembelian_detail`
--

INSERT INTO `pembelian_detail` (`id_pembelian_detail`, `id_pembelian`, `id_barang`, `qty`, `price`, `ppn`, `discount`, `price_netto`, `expiry`, `qty_return`, `status_return`) VALUES
(18, 14, 1, 1, 2500, 11, 0, 2775, NULL, 0, 'active'),
(19, 15, 1, 3, 2500, 11, 0, 2775, NULL, 0, 'active');

-- --------------------------------------------------------

--
-- Table structure for table `satuan`
--

CREATE TABLE `satuan` (
  `id_satuan` int(11) NOT NULL,
  `nama_satuan` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `satuan`
--

INSERT INTO `satuan` (`id_satuan`, `nama_satuan`) VALUES
(1, 'PCS'),
(2, 'Liter'),
(3, 'Bungkus'),
(4, 'Galon'),
(5, 'Kg'),
(6, 'Kardus');

-- --------------------------------------------------------

--
-- Table structure for table `supplier`
--

CREATE TABLE `supplier` (
  `id_suplier` int(11) NOT NULL,
  `kode_suplier` varchar(100) NOT NULL,
  `nama_suplier` varchar(30) NOT NULL,
  `alamat_suplier` varchar(100) NOT NULL,
  `contact_person` char(14) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `supplier`
--

INSERT INTO `supplier` (`id_suplier`, `kode_suplier`, `nama_suplier`, `alamat_suplier`, `contact_person`) VALUES
(1, 'UNLV', 'Unilever Tbk.', 'Surabaya', '021474836478'),
(2, 'WFD', 'Wings Food', 'Surabaya', '081977878878'),
(3, 'BTJ', 'Bintang Toedjoe', 'Jakarta', '081939487837'),
(4, 'DKLC', 'Dua Kelinci', 'Surabaya', '081977878878');

-- --------------------------------------------------------

--
-- Table structure for table `transaksi`
--

CREATE TABLE `transaksi` (
  `id_transaksi` int(11) NOT NULL,
  `id_kasir` int(11) NOT NULL,
  `waktu` datetime NOT NULL,
  `bayar` bigint(20) NOT NULL,
  `grand_total` bigint(20) NOT NULL,
  `kembalian` bigint(20) NOT NULL,
  `status` enum('pending','active','void','done','retur') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `transaksi`
--

INSERT INTO `transaksi` (`id_transaksi`, `id_kasir`, `waktu`, `bayar`, `grand_total`, `kembalian`, `status`) VALUES
(43, 1, '2024-06-03 07:45:17', 0, 0, 0, 'void'),
(44, 1, '2024-06-03 07:48:13', 0, 0, 0, 'void'),
(45, 1, '2024-06-03 08:20:57', 0, 0, 0, 'void'),
(46, 1, '2024-06-03 08:30:10', 0, 0, 0, 'void'),
(47, 1, '2024-06-03 08:30:37', 0, 0, 0, 'void'),
(48, 1, '2024-06-04 06:29:46', 0, 0, 0, 'void'),
(49, 1, '2024-06-05 20:57:14', 0, 0, 0, 'void'),
(50, 1, '2024-06-05 21:46:10', 5000, 3386, 1614, 'done'),
(51, 1, '2024-06-05 21:48:23', 0, -3386, 0, 'retur'),
(52, 1, '2024-06-05 21:49:18', 0, 0, 0, 'void'),
(53, 1, '2024-06-05 21:51:33', 10000, 6772, 3228, 'done'),
(54, 1, '2024-06-05 21:53:28', 0, 0, 0, 'active');

-- --------------------------------------------------------

--
-- Table structure for table `transaksi_detail`
--

CREATE TABLE `transaksi_detail` (
  `id_transaksi_detail` int(11) NOT NULL,
  `id_barang` int(11) NOT NULL,
  `id_transaksi` int(11) NOT NULL,
  `qty` int(30) NOT NULL,
  `harga_beli` int(11) NOT NULL,
  `harga_jual` int(11) NOT NULL,
  `updated_at` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `transaksi_detail`
--

INSERT INTO `transaksi_detail` (`id_transaksi_detail`, `id_barang`, `id_transaksi`, `qty`, `harga_beli`, `harga_jual`, `updated_at`) VALUES
(93, 4, 43, 1, 4000, 4500, '2024-06-03 07:45:19'),
(94, 4, 44, 5, 4000, 4400, '2024-06-03 08:10:19'),
(97, 4, 47, 3, 4000, 4400, '2024-06-03 09:02:46'),
(98, 1, 47, 4, 2775, 3372, '2024-06-03 09:02:55'),
(99, 2, 47, 8, 2220, 2270, '2024-06-03 09:03:53'),
(100, 1, 50, 1, 2775, 3386, '2024-06-05 21:48:01'),
(101, 1, 51, -1, 2775, 3386, '2024-06-05 21:49:08'),
(102, 1, 53, 2, 2775, 3386, '2024-06-05 21:52:55');

--
-- Triggers `transaksi_detail`
--
DELIMITER $$
CREATE TRIGGER `updatestokjual1` AFTER DELETE ON `transaksi_detail` FOR EACH ROW begin update barang set stok_display=stok_display+old.qty where id_barang=old.id_barang;END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Structure for view `ds_markup`
--
DROP TABLE IF EXISTS `ds_markup`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `ds_markup`  AS SELECT `pembelian`.`id_pembelian` AS `id_pembelian`, `pembelian`.`no_faktur` AS `no_faktur`, `pembelian`.`tgl_faktur` AS `tgl_faktur`, `barang`.`id_barang` AS `id_barang`, `barang`.`barcode` AS `barcode`, `barang`.`nama_barang` AS `nama_barang`, `pembelian_detail`.`qty` AS `pembelian_detail.qty`, `pembelian_detail`.`price` AS `pembelian_detail.price`, `pembelian_detail`.`ppn` AS `pembelian_detail.ppn`, `pembelian_detail`.`discount` AS `pembelian_detail.discount`, `pembelian_detail`.`price_netto` AS `pembelian_detail.price_netto`, `barang`.`harga_jual1` AS `harga_satuan`, round((`barang`.`harga_jual1` - `pembelian_detail`.`price_netto`) / `pembelian_detail`.`price_netto` * 100,2) AS `profit1`, `barang`.`qty2` AS `qty2`, `barang`.`harga_jual2` AS `harga_qty2`, round((`barang`.`harga_jual2` - `pembelian_detail`.`price_netto`) / `pembelian_detail`.`price_netto` * 100,2) AS `profit2`, `barang`.`qty3` AS `qty3`, `barang`.`harga_jual3` AS `harga_qty3`, round((`barang`.`harga_jual3` - `pembelian_detail`.`price_netto`) / `pembelian_detail`.`price_netto` * 100,2) AS `profit3`, `barang`.`qty4` AS `qty4`, `barang`.`harga_jual4` AS `harga_qty4`, round((`barang`.`harga_jual4` - `pembelian_detail`.`price_netto`) / `pembelian_detail`.`price_netto` * 100,2) AS `profit4`, `pembelian`.`status` AS `status_pembelian` FROM ((`pembelian` join `pembelian_detail` on(`pembelian`.`id_pembelian` = `pembelian_detail`.`id_pembelian`)) join `barang` on(`pembelian_detail`.`id_barang` = `barang`.`id_barang`)) WHERE `pembelian`.`status` = 'saved' ;

-- --------------------------------------------------------

--
-- Structure for view `ds_report_expiry`
--
DROP TABLE IF EXISTS `ds_report_expiry`;

CREATE ALGORITHM=TEMPTABLE DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `ds_report_expiry`  AS SELECT `pembelian_detail`.`id_barang` AS `id_barang`, `pembelian`.`no_faktur` AS `no_faktur`, `pembelian`.`tgl_faktur` AS `tgl_faktur`, `pembelian_detail`.`expiry` AS `expiry`, `pembelian`.`lama_jatuh_tempo` AS `lama_jatuh_tempo`, `supplier`.`kode_suplier` AS `kode_suplier`, `supplier`.`nama_suplier` AS `nama_suplier`, `barang`.`barcode` AS `barcode`, `barang`.`nama_barang` AS `nama_barang`, `pembelian_detail`.`qty` AS `qty`, to_days(`pembelian_detail`.`expiry`) - to_days(current_timestamp()) AS `expire_in` FROM (((`pembelian_detail` left join `barang` on(`pembelian_detail`.`id_barang` = `barang`.`id_barang`)) join `pembelian` on(`pembelian`.`id_pembelian` = `pembelian_detail`.`id_pembelian`)) join `supplier` on(`supplier`.`id_suplier` = `pembelian`.`id_supplier`)) WHERE `pembelian_detail`.`status_return` = 'active' ORDER BY to_days(`pembelian_detail`.`expiry`) - to_days(current_timestamp()) ASC ;

-- --------------------------------------------------------

--
-- Structure for view `ds_report_penjualan`
--
DROP TABLE IF EXISTS `ds_report_penjualan`;

CREATE ALGORITHM=TEMPTABLE DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `ds_report_penjualan`  AS SELECT `transaksi`.`id_transaksi` AS `id_transaksi`, `transaksi`.`waktu` AS `waktu`, concat(date_format(`transaksi`.`waktu`,'%d%m%Y%H%i%S'),'',`transaksi`.`id_kasir`) AS `kode_transaksi`, `transaksi`.`id_kasir` AS `id_kasir`, `transaksi`.`bayar` AS `bayar`, `transaksi`.`grand_total` AS `grand_total`, `transaksi`.`kembalian` AS `kembalian`, `transaksi`.`status` AS `status`, `transaksi_detail`.`id_transaksi_detail` AS `id_transaksi_detail`, `barang`.`barcode` AS `barcode`, `barang`.`nama_barang` AS `nama_barang`, `transaksi_detail`.`qty` AS `qty`, `transaksi_detail`.`harga_beli` AS `harga_beli`, `transaksi_detail`.`harga_jual` AS `harga_jual` FROM ((`transaksi` left join `transaksi_detail` on(`transaksi_detail`.`id_transaksi` = `transaksi`.`id_transaksi`)) join `barang` on(`transaksi_detail`.`id_barang` = `barang`.`id_barang`)) WHERE `transaksi`.`status` = 'done' OR `transaksi`.`status` = 'retur' ;

-- --------------------------------------------------------

--
-- Structure for view `ds_transaksi_pembelian`
--
DROP TABLE IF EXISTS `ds_transaksi_pembelian`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `ds_transaksi_pembelian`  AS SELECT `pembelian_detail`.`id_pembelian_detail` AS `id_pembelian_detail`, `pembelian`.`id_pembelian` AS `id_pembelian`, `pembelian`.`no_faktur` AS `no_faktur`, `pembelian_detail`.`id_barang` AS `id_barang`, `barang`.`barcode` AS `barcode`, `barang`.`nama_barang` AS `nama_barang`, `barang`.`stok_display`+ `barang`.`stok_gudang` AS `stok`, `pembelian_detail`.`qty` AS `qty`, `pembelian_detail`.`price` AS `harga`, `barang`.`harga_beli` AS `harga_lama`, `pembelian_detail`.`ppn` AS `ppn`, `barang`.`ppn` AS `ppn_lama`, `pembelian_detail`.`discount` AS `discount`, `barang`.`discount` AS `discount_lama`, `pembelian_detail`.`price_netto` AS `harga_netto`, `barang`.`harga_beli_netto` AS `harga_netto_lama`, `pembelian_detail`.`qty`* `pembelian_detail`.`price_netto` AS `total`, `pembelian_detail`.`expiry` AS `expiry` FROM ((`pembelian` join `pembelian_detail` on(`pembelian`.`id_pembelian` = `pembelian_detail`.`id_pembelian`)) join `barang` on(`pembelian_detail`.`id_barang` = `barang`.`id_barang`)) ;

-- --------------------------------------------------------

--
-- Structure for view `ds_transaksi_penjualan`
--
DROP TABLE IF EXISTS `ds_transaksi_penjualan`;

CREATE ALGORITHM=TEMPTABLE DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `ds_transaksi_penjualan`  AS SELECT `transaksi_detail`.`id_transaksi_detail` AS `id_transaksi_detail`, `transaksi_detail`.`id_transaksi` AS `id_transaksi`, `barang`.`barcode` AS `barcode`, `barang`.`nama_barang` AS `nama_barang`, `transaksi_detail`.`harga_jual` AS `harga`, `transaksi_detail`.`qty` AS `qty`, `transaksi_detail`.`harga_jual`* `transaksi_detail`.`qty` AS `jumlah`, `barang`.`stok_display`+ `barang`.`stok_gudang` AS `stok`, `transaksi_detail`.`updated_at` AS `updated_at` FROM (`transaksi_detail` left join `barang` on(`transaksi_detail`.`id_barang` = `barang`.`id_barang`)) ORDER BY `transaksi_detail`.`updated_at` DESC ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `barang`
--
ALTER TABLE `barang`
  ADD PRIMARY KEY (`id_barang`);

--
-- Indexes for table `kasir`
--
ALTER TABLE `kasir`
  ADD PRIMARY KEY (`id_kasir`);

--
-- Indexes for table `mutasi`
--
ALTER TABLE `mutasi`
  ADD PRIMARY KEY (`id_mutasi`);

--
-- Indexes for table `pembelian`
--
ALTER TABLE `pembelian`
  ADD PRIMARY KEY (`id_pembelian`);

--
-- Indexes for table `pembelian_detail`
--
ALTER TABLE `pembelian_detail`
  ADD PRIMARY KEY (`id_pembelian_detail`);

--
-- Indexes for table `satuan`
--
ALTER TABLE `satuan`
  ADD PRIMARY KEY (`id_satuan`);

--
-- Indexes for table `supplier`
--
ALTER TABLE `supplier`
  ADD PRIMARY KEY (`id_suplier`);

--
-- Indexes for table `transaksi`
--
ALTER TABLE `transaksi`
  ADD PRIMARY KEY (`id_transaksi`);

--
-- Indexes for table `transaksi_detail`
--
ALTER TABLE `transaksi_detail`
  ADD PRIMARY KEY (`id_transaksi_detail`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `barang`
--
ALTER TABLE `barang`
  MODIFY `id_barang` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `kasir`
--
ALTER TABLE `kasir`
  MODIFY `id_kasir` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `mutasi`
--
ALTER TABLE `mutasi`
  MODIFY `id_mutasi` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `pembelian`
--
ALTER TABLE `pembelian`
  MODIFY `id_pembelian` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `pembelian_detail`
--
ALTER TABLE `pembelian_detail`
  MODIFY `id_pembelian_detail` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `satuan`
--
ALTER TABLE `satuan`
  MODIFY `id_satuan` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `supplier`
--
ALTER TABLE `supplier`
  MODIFY `id_suplier` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `transaksi`
--
ALTER TABLE `transaksi`
  MODIFY `id_transaksi` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=55;

--
-- AUTO_INCREMENT for table `transaksi_detail`
--
ALTER TABLE `transaksi_detail`
  MODIFY `id_transaksi_detail` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=103;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

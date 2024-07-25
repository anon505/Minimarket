-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 25, 2024 at 01:44 AM
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
  `id_suplier` int(11) DEFAULT NULL,
  `id_satuan` int(11) DEFAULT NULL,
  `barcode` varchar(254) NOT NULL,
  `nama_barang` varchar(50) DEFAULT NULL,
  `harga_beli` int(100) NOT NULL DEFAULT 0,
  `ppn` float NOT NULL DEFAULT 0,
  `discount` float NOT NULL DEFAULT 0,
  `harga_beli_netto` int(11) NOT NULL DEFAULT 0,
  `stok_display` int(30) NOT NULL DEFAULT 0,
  `stok_gudang` int(30) NOT NULL DEFAULT 0,
  `harga_jual1` int(11) NOT NULL DEFAULT 0,
  `harga_jual2` int(11) NOT NULL DEFAULT 0,
  `harga_jual3` int(11) NOT NULL DEFAULT 0,
  `harga_jual4` int(11) NOT NULL DEFAULT 0,
  `qty2` int(11) NOT NULL DEFAULT 0,
  `qty3` int(11) NOT NULL DEFAULT 0,
  `qty4` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `barang`
--

INSERT INTO `barang` (`id_barang`, `id_suplier`, `id_satuan`, `barcode`, `nama_barang`, `harga_beli`, `ppn`, `discount`, `harga_beli_netto`, `stok_display`, `stok_gudang`, `harga_jual1`, `harga_jual2`, `harga_jual3`, `harga_jual4`, `qty2`, `qty3`, `qty4`) VALUES
(1, 2, 1, '8992696407688', 'Nestle 700g', 2500, 11, 0.5, 0, 58, 57, 3386, 3372, 3316, 3191, 3, 6, 9),
(2, 2, 1, '896867700326', 'Le Minerale', 2000, 11, 0, 2220, 28, 61, 2600, 2300, 2270, 2264, 3, 8, 12),
(3, 3, 1, '7237844127560', 'Pempers Sensi', 3000, 0, 0, 3000, 27, 50, 3550, 3530, 3520, 3510, 5, 10, 15),
(4, 2, 3, '8992112011017', 'Cerebrovot1', 4000, 0, 0, 0, 12, 80, 4500, 4400, 4300, 4200, 2, 6, 10),
(5, 4, 4, '1234', 'Aqua Sedang1', 7000, 0, 0, 7000, 0, 47, 9100, 8400, 7700, 7350, 10, 20, 30),
(12, NULL, NULL, '445566', 'barang baru dateng', 1000, 0, 0, 1000, 0, 102, 5000, 4000, 3000, 2000, 3, 4, 3);

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
  `type` enum('penjualan','pembelian','bayar_hutang','pengeluaran') NOT NULL,
  `deskripsi` text NOT NULL,
  `nominal` int(11) NOT NULL,
  `created_at` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `mutasi`
--

INSERT INTO `mutasi` (`id_mutasi`, `id_reff`, `type`, `deskripsi`, `nominal`, `created_at`) VALUES
(23, 72, 'penjualan', 'PENJUALAN pada waktu: 17/07/2024 11:51:40', 11800, '2024-07-17 11:54:05'),
(24, 73, 'penjualan', 'RETUR PENJUALAN pada waktu: 17/07/2024 11:54:05', -5900, '2024-07-17 11:54:41'),
(25, 21, 'pembelian', 'PEMBELIAN secara KREDIT dengan faktur: 112233', 0, '2024-07-18 16:08:25'),
(26, 20, 'pembelian', 'update PEMBELIAN secara TUNAI dengan faktur: 112233', 7000, '2024-07-18 16:25:27'),
(27, 22, 'pembelian', 'PEMBELIAN secara KREDIT dengan faktur: 112233', -7000, '2024-07-19 16:59:57'),
(28, 23, 'pembelian', 'PEMBELIAN secara KREDIT dengan faktur: 334433', -7000, '2024-07-19 17:01:26'),
(29, 24, 'pembelian', 'PEMBELIAN secara TUNAI dengan faktur: 4545454545', 100000, '2024-07-25 06:38:40');

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
  `metode_pembayaran` enum('tunai','konsinyasi','kredit') NOT NULL DEFAULT 'tunai',
  `lama_jatuh_tempo` int(11) NOT NULL COMMENT 'lama jatuh tempo(hari) berdasarkan tgl faktur',
  `status` enum('temp','saved','mark_up') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `pembelian`
--

INSERT INTO `pembelian` (`id_pembelian`, `no_faktur`, `tgl_faktur`, `id_supplier`, `id_kasir`, `grand_total`, `metode_pembayaran`, `lama_jatuh_tempo`, `status`) VALUES
(20, '112233', '2024-07-18 16:07:35', 1, 1, 7000, 'kredit', 1, 'saved'),
(22, '334433', '2024-07-19 16:59:57', 4, 1, 7000, 'kredit', 2, 'saved'),
(23, '4545454545', '2024-07-19 17:01:26', 1, 1, 100000, 'tunai', 0, 'mark_up'),
(24, '', '2024-07-25 06:38:40', 0, 1, 0, 'tunai', 0, 'temp');

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
(22, 20, 5, 1, 7000, 0, 0, 7000, NULL, 0, 'active'),
(23, 22, 5, 1, 7000, 0, 0, 7000, NULL, 0, 'active'),
(24, 23, 12, 100, 1000, 0, 0, 1000, NULL, 0, 'active');

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
(72, 1, '2024-07-17 11:51:40', 20000, 11800, 8200, 'done'),
(73, 1, '2024-07-17 11:54:05', -5900, -5900, 0, 'retur'),
(74, 1, '2024-07-17 11:54:41', 0, 0, 0, 'void');

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
(117, 5, 72, 2, 0, 5900, '2024-07-17 11:52:10'),
(118, 5, 73, -1, 0, 5900, '2024-07-17 11:54:23'),
(119, 5, 74, 1, 0, 5900, '2024-07-17 11:55:08');

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
  MODIFY `id_barang` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `kasir`
--
ALTER TABLE `kasir`
  MODIFY `id_kasir` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `mutasi`
--
ALTER TABLE `mutasi`
  MODIFY `id_mutasi` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;

--
-- AUTO_INCREMENT for table `pembelian`
--
ALTER TABLE `pembelian`
  MODIFY `id_pembelian` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT for table `pembelian_detail`
--
ALTER TABLE `pembelian_detail`
  MODIFY `id_pembelian_detail` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

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
  MODIFY `id_transaksi` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=75;

--
-- AUTO_INCREMENT for table `transaksi_detail`
--
ALTER TABLE `transaksi_detail`
  MODIFY `id_transaksi_detail` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=120;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

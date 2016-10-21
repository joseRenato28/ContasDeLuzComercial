-- phpMyAdmin SQL Dump
-- version 4.2.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 21-Out-2016 às 21:00
-- Versão do servidor: 5.6.21
-- PHP Version: 5.6.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `deadline`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `contas`
--

CREATE TABLE IF NOT EXISTS `contas` (
`id_conta` int(11) NOT NULL,
  `data_leitura` date NOT NULL,
  `n_leitura` varchar(30) NOT NULL,
  `kw_gasto` varchar(30) NOT NULL,
  `valor_pagar` varchar(30) NOT NULL,
  `data_pagamento` date NOT NULL,
  `media_consumo` decimal(30,0) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `contas`
--

INSERT INTO `contas` (`id_conta`, `data_leitura`, `n_leitura`, `kw_gasto`, `valor_pagar`, `data_pagamento`, `media_consumo`) VALUES
(1, '2016-10-08', '111', '12', '21', '2016-10-20', '40545'),
(2, '2016-10-05', '123', '123', '11', '2016-10-14', '123'),
(3, '2016-10-22', '123', '3123', '312', '2016-10-28', '123');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `contas`
--
ALTER TABLE `contas`
 ADD PRIMARY KEY (`id_conta`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `contas`
--
ALTER TABLE `contas`
MODIFY `id_conta` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

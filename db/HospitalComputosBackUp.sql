-- MySQL dump 10.13  Distrib 8.0.39, for Linux (x86_64)
--
-- Host: localhost    Database: HospitalComputos
-- ------------------------------------------------------
-- Server version	8.0.39-0ubuntu0.24.04.2

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Computadoras`
--

DROP TABLE IF EXISTS `Computadoras`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Computadoras` (
  `IdComputadora` int NOT NULL AUTO_INCREMENT,
  `NombrePC` varchar(255) NOT NULL,
  `IP` varchar(15) NOT NULL,
  `IdServicio` int DEFAULT NULL,
  `Usuario` varchar(255) NOT NULL,
  `NombreUsuario` varchar(255) NOT NULL,
  PRIMARY KEY (`IdComputadora`),
  KEY `IdServicio` (`IdServicio`),
  CONSTRAINT `Computadoras_ibfk_1` FOREIGN KEY (`IdServicio`) REFERENCES `Servicios` (`IdServicio`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Computadoras`
--

LOCK TABLES `Computadoras` WRITE;
/*!40000 ALTER TABLE `Computadoras` DISABLE KEYS */;
INSERT INTO `Computadoras` VALUES (1,'FIN-PAG-003','',1,'Sol Monti',''),(2,'FIN-COM-001','192.168.6.49',1,'Emilse','EBISCALDI'),(3,'UTI-MED-003','192.168.5.55',2,'Medicos Guardia','Medicos Guardia'),(4,'GRD-MED-002','192.168.6.59',2,'Medicos Guardia','Medicos Guardia'),(5,'GRD-MED-001','192.168.6.229',2,'Medicos Guardia','Medicos Guardia');
/*!40000 ALTER TABLE `Computadoras` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `EntregaToner`
--

DROP TABLE IF EXISTS `EntregaToner`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `EntregaToner` (
  `IdEntregaToner` int NOT NULL AUTO_INCREMENT,
  `IdToner` int NOT NULL,
  `Cantidad` int NOT NULL,
  `Descripcion` varchar(50) DEFAULT NULL,
  `IdServicio` int DEFAULT NULL,
  PRIMARY KEY (`IdEntregaToner`),
  KEY `fk_entrega_servicio` (`IdServicio`),
  KEY `fk_entrega_servicio_toner` (`IdToner`),
  CONSTRAINT `fk_entrega_servicio` FOREIGN KEY (`IdServicio`) REFERENCES `Servicios` (`IdServicio`),
  CONSTRAINT `fk_entrega_servicio_toner` FOREIGN KEY (`IdToner`) REFERENCES `Toner` (`IdToner`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EntregaToner`
--

LOCK TABLES `EntregaToner` WRITE;
/*!40000 ALTER TABLE `EntregaToner` DISABLE KEYS */;
INSERT INTO `EntregaToner` VALUES (1,1,1,' ',5);
/*!40000 ALTER TABLE `EntregaToner` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Impresoras`
--

DROP TABLE IF EXISTS `Impresoras`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Impresoras` (
  `IdImpresora` int NOT NULL AUTO_INCREMENT,
  `NombreImpresora` varchar(255) NOT NULL,
  `IdComputadora` int DEFAULT NULL,
  `IdToner` int DEFAULT NULL,
  PRIMARY KEY (`IdImpresora`),
  KEY `IdComputadora` (`IdComputadora`),
  KEY `fk_impresora_toner` (`IdToner`),
  CONSTRAINT `fk_impresora_toner` FOREIGN KEY (`IdToner`) REFERENCES `Toner` (`IdToner`),
  CONSTRAINT `Impresoras_ibfk_1` FOREIGN KEY (`IdComputadora`) REFERENCES `Computadoras` (`IdComputadora`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Impresoras`
--

LOCK TABLES `Impresoras` WRITE;
/*!40000 ALTER TABLE `Impresoras` DISABLE KEYS */;
/*!40000 ALTER TABLE `Impresoras` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Reparaciones`
--

DROP TABLE IF EXISTS `Reparaciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Reparaciones` (
  `IdReparacion` int NOT NULL AUTO_INCREMENT,
  `IdComputadora` int DEFAULT NULL,
  `Descripción` varchar(255) NOT NULL,
  `Fecha` timestamp NOT NULL,
  PRIMARY KEY (`IdReparacion`),
  KEY `IdComputadora` (`IdComputadora`),
  CONSTRAINT `Reparaciones_ibfk_1` FOREIGN KEY (`IdComputadora`) REFERENCES `Computadoras` (`IdComputadora`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Reparaciones`
--

LOCK TABLES `Reparaciones` WRITE;
/*!40000 ALTER TABLE `Reparaciones` DISABLE KEYS */;
/*!40000 ALTER TABLE `Reparaciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Servicios`
--

DROP TABLE IF EXISTS `Servicios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Servicios` (
  `IdServicio` int NOT NULL AUTO_INCREMENT,
  `NombreServicio` varchar(255) NOT NULL,
  `Descripción` varchar(255) NOT NULL,
  PRIMARY KEY (`IdServicio`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Servicios`
--

LOCK TABLES `Servicios` WRITE;
/*!40000 ALTER TABLE `Servicios` DISABLE KEYS */;
INSERT INTO `Servicios` VALUES (1,'Financiera','Descripción de la financiera'),(2,'Guardia','Descripción de la guardia'),(3,'Pediatría','Descripción de pediatría'),(4,'Personal','Descripción del personal'),(5,'Salud Laboral','');
/*!40000 ALTER TABLE `Servicios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Toner`
--

DROP TABLE IF EXISTS `Toner`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Toner` (
  `IdToner` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(100) NOT NULL,
  `Cantidad` int NOT NULL,
  PRIMARY KEY (`IdToner`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Toner`
--

LOCK TABLES `Toner` WRITE;
/*!40000 ALTER TABLE `Toner` DISABLE KEYS */;
INSERT INTO `Toner` VALUES (1,'85',1);
/*!40000 ALTER TABLE `Toner` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-10-03 11:44:16

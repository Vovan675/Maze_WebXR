<?php
require("connection.php");

$name = $_POST["name"];
$time = $_POST["time"];

$sql = "SELECT name, time FROM players WHERE name = '" . $name . "'";
$res = $conn->query($sql);

if ($res->num_rows > 0)
{
    //Already exists, just update
    $sql = "UPDATE players SET time = " . $time . " WHERE name = '" . $name . "'";
    $res = $conn->query($sql);
    if (!$res)
    {
        echo $conn->error;
    }
}
else
{
    //Insert new time
    $sql = "INSERT INTO players (name, time) VALUES ('" . $name . "', " . $time . ")";
    $res = $conn->query($sql);
    if (!$res)
    {
        echo $conn->error;
    }
}

?>
<?php
require("connection.php");
$name = $_POST["name"];

$sql = "SELECT * FROM players WHERE name = '" . $name . "'";
$res = $conn->query($sql);
echo $name;

if ($res->num_rows > 0)
{
    //Already created
}
else
{
    $sql = "INSERT INTO players (name, time) VALUES ('" . $name . "', -1)";
    $res = $conn->query($sql);
    if (!$res)
    {
        echo $con->error_log;
    }
}

$conn->close();
?>
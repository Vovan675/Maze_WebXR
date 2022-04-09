<?php
require("connection.php");

$sql = "SELECT * FROM players ORDER BY -time";
$res = $conn->query($sql);


if ($res->num_rows > 0)
{
    echo "<table cellspacing='0' class='header-table'>
    <thead>
    <tr>
    <th>№</th>
    <th>Name</th>
    <th>Time</th>
    </tr>
    </thead>
    </table>";

    echo "<div class='content-table'><table cellspacing='0'>";
    echo "<tbody>";
    
    $place = 1;
    while ($row = $res->fetch_assoc())
    {
        printf("<tr><td>%d</td><td>%s</td><td>%s</td></tr>", $place, $row["name"], $row["time"]);
        $place++;
    }
    echo "</tbody>";
    echo "</table></div>";
}
else
{
    echo $conn->error;
}

$conn->close();
?>
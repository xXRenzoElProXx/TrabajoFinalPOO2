let tbodys = document.getElementById("tbody");
let elementosFila = tbodys.getElementsByTagName("td");
var real = elementosFila.length - 1;

if (real > 0) {
    document.getElementById("vacio").style.display = "none";
    var a = (elementosFila[4].innerHTML).replace("S/", "");
    var e = a.replace(".00", "");
    var o = Number(e);
    document.getElementById("tot").innerHTML = "El precio total es de S/." + o;

    var a2 = (elementosFila[11].innerHTML).replace("S/", "");
    var e2 = a2.replace(".00", "");
    var o2 = Number(e2);
    var suma1 = o + o2;
    document.getElementById("tot").innerHTML = "El precio total es de S/." + suma1;

    var a3 = (elementosFila[18].innerHTML).replace("S/", "");
    var e3 = a3.replace(".00", "");
    var o3 = Number(e3);
    var suma2 = o + o2 + o3;
    document.getElementById("tot").innerHTML = "El precio total es de S/." + suma2;

    var a4 = (elementosFila[25].innerHTML).replace("S/", "");
    var e4 = a4.replace(".00", "");
    var o4 = Number(e4);
    var suma3 = o + o2 + o3 + o4;
    document.getElementById("tot").innerHTML = "El precio total es de S/." + suma3;

    var a5 = (elementosFila[32].innerHTML).replace("S/", "");
    var e5 = a5.replace(".00", "");
    var o5 = Number(e5);
    var total_precio = o + o2 + o3 + o4 + o5;
    document.getElementById("tot").innerHTML = "El precio total es de S/." + total_precio;
} else {
    document.getElementById("pagar").style.display = "none";
    document.getElementById("vacio").innerHTML = "El carrito esta Vacio";
}
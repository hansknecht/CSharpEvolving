function getFromInput() {
    return {
        "productid": GetValue("productid"),
        "name": GetValue("name"),
        "productnumber": GetValue("productnumber"),
        "color": getValue("color"),
        "safetystocklevel": getValue("safetystockvalue"),
        "reorderpoint": getValue("reorderpoint"),
        "standardcost": getValue("standardcost"),
        "listprice": getValue("listprice"),
        "size": getValue("size"),
        "weight": getValue("weight"),
        "daystomanufacture": getValue("daystomanufacture"),
        "sellstartdate": new Date(getValue("sellstartdate")),
    }
}

function setInput() {
    setValue("productid", product.productid);
    setValue("name", product.name);
    setValue("productnumber", product.productnumber);
    setValue("color", product.color);
    setValue("safetystocklevel", product.safetystocklevel);
    setValue("reorderpoint", product.reorderpoint);
    setValue("standardcost", product.standardcost);
    setValue("listprice", product.listprice);
    setValue("size", product.size);
    setValue("weight", product.weight);
    setValue("daystomanufacture", product.daystomanufacture);
    setValue("sellstartdate", product.sellstartdate);
}

function clearInput() {
    setValue("productid", "0");
    setValue("name", "");
    setValue("productnumber", "");
    setValue("color", "");
    setValue("safetystocklevel", "0");
    setValue("reorderpoint", "0");
    setValue("standardcost", "0");
    setValue("listprice", "0");
    setValue("size", "0");
    setValue("weight", "0");
    setValue("daystomanufacture", "0");
    setValue("sellstartdate", new Date().toDateString());

}
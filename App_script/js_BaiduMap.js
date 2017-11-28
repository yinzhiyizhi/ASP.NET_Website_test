var map = new BMap.Map("div_baiduMap");
map.centerAndZoom(new BMap.Point(116.404, 39.915), 11);

//0.控件设置
//平移缩放
map.addControl(new BMap.NavigationControl());
//鼠标滚轮放大缩小
map.enableScrollWheelZoom();

//1.添加点击侦听 获取地图上点的坐标
//map.addEventListener("click", function (e) {
//    alert(e.Point.lng + "," + e.point.lat);
//});

//2.添加静态标识
var _p = new BMap.Point(116.321565, 39.979607);
//var _m1 = new BMap.Marker(_p);
//map.addOverlay(_m1);

//3.跳动的动画
//_m1.setAnimation(BMAP_ANIMATION_BOUNCE);

//4.弹出窗口
//var _info1 = new BMap.InfoWindow("易美逊总部");
//_m1.addEventListener("mouseover", function () { this.openInfoWindow(_info1);});
//_m1.addEventListener("mouseout", function () { this.closeInfoWindow(_info1); });

//5.标签提示
var _opts = { position: _p, offset: new BMap.Size(25, -10) };
var _lab = new BMap.Label("公司总部", _opts);
map.addOverlay(_lab);
_lab.setStyle({ color: "orange", fontsize: "14px", padding: "6px" });

//6.自定义标识
var _icon = new BMap.Icon("../App_imgs/LOGO40.png", new BMap.Size(40, 40));
var _m2 = new BMap.Marker(_p, { icon: _icon });
map.addOverlay(_m2);
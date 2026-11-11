using System;
using System.Collections.Generic;
public interface IRepairable{void StartRepair();void CompleteRepair();double CalculateRepairCost();}
public static class ValidationHelper{public static bool IsValidSerial(string s){return !string.IsNullOrWhiteSpace(s)&&s.Length>=5;}}
public delegate void StatusHandler(object sender,string s);
public abstract class Device:IRepairable{
private string _serial,_brand,_model,_status;private double _cost;
public static int TotalDevices{get;private set;}public static double TotalValue{get;private set;}
public string Serial{get{return _serial;}}
public string Brand{get{return _brand;}set{if(string.IsNullOrWhiteSpace(value))throw new ArgumentException("empty");_brand=value;}}
public string Model{get{return _model;}set{if(string.IsNullOrWhiteSpace(value))throw new ArgumentException("empty");_model=value;}}
public string Status{get{return _status;}protected set{_status=value;if(StatusChanged!=null)StatusChanged(this,value);}}
public double BaseCost{get{return _cost;}set{if(value<0)throw new ArgumentException("neg");_cost=value;}}
public event StatusHandler StatusChanged;
protected Device(string s,string b,string m,double c){if(!ValidationHelper.IsValidSerial(s))throw new ArgumentException("serial");_serial=s;Brand=b;Model=m;BaseCost=c;Status="Pending";TotalDevices++;}
public abstract double CalculateRepairCost();
public double WithDiscount(double p){double c=CalculateRepairCost();return c-(c*p/100);}
public void StartRepair(){Status="In Repair";}public void CompleteRepair(){Status="Repaired";TotalValue+=CalculateRepairCost();}
public virtual void Show(){Console.WriteLine(GetType().Name+" "+Brand+" "+Model+" | "+Serial+" | "+Status+" | "+CalculateRepairCost());}
}
public class Refrigerator:Device{public int Cap{get;set;}public bool Freezer{get;set;}
public Refrigerator(string s,string b,string m,double c,int cap,bool f):base(s,b,m,c){Cap=cap;Freezer=f;}
public override double CalculateRepairCost(){double x=BaseCost;if(Cap>400)x+=50;if(Freezer)x+=30;return x;}
public void Defrost(){Console.WriteLine("Defrost "+Brand);}}
public class WashingMachine:Device{public int Kg{get;set;}public bool Auto{get;set;}
public WashingMachine(string s,string b,string m,double c,int kg,bool a):base(s,b,m,c){Kg=kg;Auto=a;}
public override double CalculateRepairCost(){double x=BaseCost;if(Kg>=8)x+=40;if(Auto)x+=25;return x;}
public void Spin(){Console.WriteLine("Spin "+Brand);}}
public class AirConditioner:Device{public int BTU{get;set;}public string Gas{get;set;}
public AirConditioner(string s,string b,string m,double c,int btu,string g):base(s,b,m,c){BTU=btu;Gas=g;}
public override double CalculateRepairCost(){double x=BaseCost;if(BTU>=24000)x+=60;if(Gas=="R410")x+=20;return x;}
public void Clean(){Console.WriteLine("Clean "+Brand);}}
public class MaintenanceCenter{private List<Device> list=new List<Device>();
public void Add(Device d){d.StatusChanged+=delegate(object sender,string s){Device v=(Device)sender;Console.WriteLine("[Alert] "+v.Brand+" -> "+s);};list.Add(d);}
public void ShowAll(){Console.WriteLine("--- All ---");foreach(Device d in list)d.Show();}
public double Total(){double t=0;foreach(Device d in list)t+=d.CalculateRepairCost();return t;}}
public class Program{public static void Main(){
Console.WriteLine("=== Maintenance Center ===");
MaintenanceCenter c=new MaintenanceCenter();
Device f=new Refrigerator("SN-12345","LG","GR-500",100,450,true);
Device w=new WashingMachine("SN-67890","Samsung","WF-800",80,9,true);
Device a=new AirConditioner("SN-11111","Midea","MS-12000",120,24000,"R410");
c.Add(f);c.Add(w);c.Add(a);c.ShowAll();
f.StartRepair();f.CompleteRepair();((Refrigerator)f).Defrost();
w.StartRepair();w.CompleteRepair();((WashingMachine)w).Spin();
a.StartRepair();a.CompleteRepair();((AirConditioner)a).Clean();
c.ShowAll();
Console.WriteLine("Total Devices: "+Device.TotalDevices);
Console.WriteLine("Total Value: "+Device.TotalValue);
Console.WriteLine("Total Cost: "+c.Total());
Console.WriteLine("Fridge Discount 10%: "+f.WithDiscount(10));
}}
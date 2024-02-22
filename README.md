# Flights Simulation Aerosonde UAV
**tl;dr:** <br/>
Bir İnsansız Hava Aracının dinamiğinin Matlab Simulink ile modellenmesi ve Unity 3D ortamında dinamik olarak simüle edilmesi. <br/>
<br/>
**Requirements:**
- Unity3d
- Matlab/Simulink

**VIDEO**
[<img src="https://i.hizliresim.com/1ncj8rj.png" width="100%">](https://www.youtube.com/watch?v=LTRineOdSDI "Aerosonde Flight Simulation")

# INTRODUCTION
Bu proje, "Small Unmanned Aircraft" kitabındaki Aerosonde Unmanned Air
Vehicle (UAV) uçağının aerodinamik verilerini temel alıyor. Uçağın dinamiği
Matlab Simulink’te modellemiş, simülasyonunu ise Unity ortamında gerçekleştirmiştir.
Pilot girdileri için bir Joystick kontrolcüsü kullanılmış ve uçağın
dinamiğini tanımlamak için Six Degree of Freedom (6-DOF) denklemleri kullanılmıştır.
Modelin gerçek dünyaya uygunluğu için ISA atmosfer modeli
ve bir rüzgar modeli oluşturulmuş, ayrıca Simulink ve Unity arasında UDP
bağlantısı kurulmuştur. Son olarak Unity’de çevre ve uçak modeli oluşturulmuştur.
Joystick ile gönderilen pilot girdileri uçağın kontrol yüzeylerini
hareket ettirir, bu da aerodinamik kuvvet ve momentlerde değişikliğe neden
olur. Bu değişen kuvvetler uçağın hızını, açısal hızını, konumunu ve
açısal oryantasyonunu değiştirir. Elde edilen veriler UDP bağlantısı ile Matlab
Simulink’ten Unity ortamına iletilir ve C# dilinde okunarak uçak modeliyle
eşleştirilir. Bu sayede uçağın hareket değişimleri dinamik olarak Unity ortamında
gözlemlenir

# MATLAB SIMULINK 
![Simulink](https://github.com/EmirYuksell/flight_simulation/assets/159529847/6febbaa8-d639-4411-8630-e6ae75af5169)<br/>

<br/>
- **JOYSTICK CONTROLLER BLOCK:**  <br/> Pilot girdileri ile uçak kontrol yüzeylerinin açılarının ve motor itki düzeyinin değişimini sağlar.<br/>
- **WIND MODEL BLOCK:** <br/> Gerçekçi bir simülasyon için 3 boyutta sabit hızda rüzgar ve sürekli değişen gust oluşumunu sağlar.<br/>
- **AERODYNAMIC FORCES AND MOMENTS BLOCK:** <br/> Değişen girdiler ile Aerosonde uçağı için referans alınan aerodinamik bilgileri kullanarak anlık olarak aerodinamik kuvvet ve moment hesaplar.<br/>
- **6 DOF MODEL BLOCK :** <br/> Hesaplanan aerodinamik kuvvet ve momentleri kullanarak uçağın 3 boyutta hız, aısal hız dolayısıyla konum ve açısal oryantasyonunu hesaplar.<br/>
- **ISA ATMOSPHERE MODEL BLOCK:** <br/> Gerçekçi bir simülasyon için değişen irtifa miktarına göre uygun hava yoğunluğunu hesaplar.<br/>
- **UNITY CONNECTION UDP BLOCK:** <br/> Uçağı simülasyon ortamında görüntülüyebilmek için elde edilen konum ve açısal oryantasyon bilgilerini UDP bağlantısı kurarak Unity ortamına gönderir.<br/>

# UNITY 3D 
![unity_foto](https://github.com/samies3468/aerosonde_flight_simulation/assets/72666457/7361f30b-0c44-4dde-8330-9b6aeed4512a) <br/>
- Dinamiği oluşturulan uçağın, pilot girdilerine göre dinamik olarak görüntülenmesi için gerekli olan ortamın hazırlandığı programdır.
Uçağı temsil etmesi adına TB2 uçağının CAD çizimi kullanılmıştır. 
Düzgün bir referenas oluşturması için Unity asset storedan alınan harita ve assetler konfigüre edilerek simülasyon için uygun bir ortam sağlanmıştır. 
UDP bağlantısı ile Simulink üzerinden gönderilen veriler C# dili kullanılarak okunur ve uçak modeliyle
eşleştirilir. Bu sayede uçağın hareket değişimleri dinamik olarak Unity ortamında gözlemlenir.
Ekstra olarak uçağın durum değişkenleri anlık olarak ekranda kullanıcının görebileceği şekilde konumlandırılmıştır.







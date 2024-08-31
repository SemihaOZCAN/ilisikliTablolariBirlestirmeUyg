select  HAREKETID,URUNAD,(AD +' '+ SOYAD) as'MUSTERI',ADSOYAD ,TblHareketler.FIYAT  from TblHareketler 
inner join TblUrunler
on
TblHareketler.URUN=TblUrunler.URUNID
inner join TblMusteriler
on 
TblHareketler.MUSTERI=TblMusteriler.MUSTERIID
inner join TblPersoneller
on
TblHareketler.PERSONEL=TblPersoneller.PERSONELID




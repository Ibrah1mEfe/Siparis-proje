document.addEventListener('DOMContentLoaded', function() {
    var girisYapButon = document.getElementById('GirisYap1');
    var buyukKutu1 = document.getElementById('buyukKutu1');

    girisYapButon.addEventListener('click', function() {
       
        buyukKutu1.style.display = (buyukKutu1.style.display === 'none' || buyukKutu1.style.display === '') ? 'flex' : 'none';

       
        buyukKutu1.scrollIntoView({ behavior: 'smooth', block: 'start' });
        
    });
});

document.addEventListener('DOMContentLoaded', function() {
    var girisYapButon = document.getElementById('KayitOl1');
    var buyukKbuyukKutu2utu1 = document.getElementById('buyukKutu2');

    girisYapButon.addEventListener('click', function() {
        
        buyukKutu2.style.display = (buyukKutu2.style.display === 'none' || buyukKutu2.style.display === '') ? 'flex' : 'none';

        
        buyukKutu2.scrollIntoView({ behavior: 'smooth', block: 'start' });
        
    });
});

function submitForm(event) {
   
    event.preventDefault();

   
}
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Visitor.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="DECXML_Maximillian_Leonard.Views.Visitor.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../Content/About.css" rel="stylesheet" />
    <div class="about">
        <p class="brand-name">Éclat</p>
        <h1>About Us</h1>
        <p class="introduction">Established in 2024, Éclat strives to transform the world of fragrances through innovative notes. Our goal is to enchant with unique fragrances. Experience our newest adventures and customer testimonials.</p>
        <hr style="width: 20%; border: 2.5px solid black; opacity: 1; margin-bottom: 25px" />

        <p class="body">
            In the vibrant heart of Kuala Lumpur, a spark of audacity ignited a fragrance revolution. The impetus? Contemplating a 100ml perfume priced at an astonishing RM100, each spray akin to the cost of a lavish indulgence. Frustration morphed into inspiration, propelling us to carve our narrative in the scented tapestry.       
        </p>

        <img src="../../Image/WebContent/about-image1.jpg" alt="about image one" />
        <p class="body">Imagine the scene: a chance encounter with an idea so daring it could only unfold in a bustling Kuala Lumpur marketplace. The scarcity of affordable yet exquisite fragrances birthed a venture that defied conventions. Thus, commenced the immersive odyssey into the mystical world of perfumery, where every essence whispered untold stories.</p>
        <p class="body">
            Years transpired, marked by fervent exploration and mentorship from three revered perfumers. In our relentless pursuit of olfactory mastery, we unearthed a truth – the soul of an exceptional perfume lies in its ability to evoke adoration from humanity. We envisioned crafting not just a fragrance but a symphony that elevates self-admiration and infuses mundane days with spellbinding tales. With unyielding determination, Éclat refines its concoctions, using only the most exceptional ingredients. Today, Éclat stands adorned with accolades, recognized as a trailblazer in the realm of perfumery. Through innovation and a steadfast commitment to creating transcendent perfumes, Éclat beckons those seeking an olfactory adventure. As we democratize the sensorial luxury of exquisite fragrances, Éclat invites all to indulge in the symphony of scents, where each bottle holds a universe of enchantment without the shackles of exorbitance.       
        </p>
        <img src="../../Image/WebContent/about-image2.jpg" alt="about image two"/>
        <img src="../../Image/WebContent/about-image3.jpg" alt="about image three"/>

        <hr style="width: 20%; border: 2.5px solid black; opacity: 1; margin: 50px 0 15px;" />

        <h2 id="contact-us" style="margin: 0.75rem 0 1rem; font-weight: 700; font-size: 2rem; font-family: 'Manrope'">Our Contact</h2>

        <div class="contact-card">
            <div class="social-media" style="display: flex; flex-direction: column;">
                <h3 class="mb-3">Social Media</h3>
                <div class="socmed-cont">
                    <a href="https://twitter.com/?lang=en" target="_blank"><i class="fa-brands fa-square-x-twitter"></i></a>
                    <a href="https://www.instagram.com/?hl=en" target="_blank"><i class="fa-brands fa-square-instagram"></i></a>
                    <a href="https://www.facebook.com/" target="_blank"><i class="fa-brands fa-square-facebook"></i></a>
                </div>
                <div class="socmed-cont">
                    <a href="https://www.youtube.com/" target="_blank"><i class="fa-brands fa-square-youtube"></i></a>
                    <a href="https://www.linkedin.com/in/maximillianleonard1508/" target="_blank"><i class="fa-brands fa-linkedin"></i></a>
                </div>
            </div>
            <div class="official-contact">
                <div class="email">
                    <h3 class="mb-3">Email</h3>
                    <p><i class="me-1 fa-solid fa-envelope"></i>Corporate Email: <a href="https://mail.google.com/mail/?view=cm&to=eclat.corporate@gmail.com&su=CorporateSupport&body=Hello" target="_blank">eclat.corporate@gmail.com</a></p>
                    <p><i class="me-1 fa-solid fa-envelope"></i>Customer Service: <a href="https://mail.google.com/mail/?view=cm&to=eclat.cs@gmail.com&su=CustomerSupport&body=Hello" target="_blank">eclat.cs@gmail.com</a></p>
                </div>

                <div class="phone">
                    <h3 class="mb-3">Phone</h3>
                    <p><i class="me-1 fs-4 fa-brands fa-square-whatsapp"></i>Whatsapp: <a href="https://wa.me/601112212480?text=Hello%20Eclat,%20I%20have%20Inquiries%20that%20needs%20your%20support!" target="_blank">01112212480</a></p>
                    <p><i class="me-1 fa-solid fa-phone"></i>24/7 Customer Call Center: <a href="tel:123-123-1234">01231231234</a></p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

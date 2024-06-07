<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>

	<xsl:template match="/">
		<xsl:if test="count(products/product[gender='unisex']) > 0">
			<xsl:for-each select="products/product[gender='unisex']">
				<a class="container-shadow" style="align-items: center; padding: 0; display:flex; flex-direction:column; width: 13.1rem; height:17rem; text-decoration: none; border:solid 1px grey; border-radius: 10px; color:black">
					<xsl:attribute name="href">
						product-details?Id=<xsl:value-of select="Id"/>
					</xsl:attribute>
					<img style="width: 100%; height:12.5rem; aspect-ratio:1/1; object-fit:cover; border-radius:10px 10px 0 0">
						<xsl:attribute name="src">
							../../<xsl:value-of select="image"/>
						</xsl:attribute>
					</img>
					<div style="margin-top: 7.5px;width:90%">
						<span class="fs-5" style="font-weight:500;">
							<xsl:choose>
								<xsl:when test="string-length(name) > 13">
									<xsl:value-of select="substring(name, 1, 13)" />...
								</xsl:when>
								<xsl:otherwise>
									<xsl:value-of select="name"/>
								</xsl:otherwise>
							</xsl:choose>
						</span>
					</div>
					<div style="width:90%; display:flex; flex-direction:row; justify-content:space-between">
						<span class="fs-5" style="align-self:start">
							RM <xsl:value-of select ="price"/>
						</span>
						<span class="fs-6" style="color: grey;">
							<xsl:choose>
								<xsl:when test="type = 'edt'">
									EDT
								</xsl:when>
								<xsl:when test="type = 'edp'">
									EDP
								</xsl:when>
								<xsl:otherwise>
									Parfum
								</xsl:otherwise>
							</xsl:choose>
						</span>
					</div>
				</a>
			</xsl:for-each>
		</xsl:if>
		<xsl:if test="count(products/product[gender='unisex']) = 0">
			<p style="font-weight: bold; margin:0 auto; font-size:16px">No available product!</p>
		</xsl:if>
	</xsl:template>
</xsl:stylesheet>

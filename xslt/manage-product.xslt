<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
	<xsl:template match="/">
		<xsl:for-each select="products/product">
			<tr>
				<td>
					<xsl:value-of select="Id"/>
				</td>
				<td>
					<xsl:value-of select="name"/>
				</td>
				<td>
					<xsl:value-of select="type"/>
				</td>
				<td>
					<xsl:value-of select="gender"/>
				</td>
				<td>
					<xsl:value-of select="note"/>
				</td>
				<td>
					<xsl:value-of select="price"/>
				</td>
				<td>
					<xsl:value-of select="stock"/>
				</td>
				<td>
					<a style="color: black;">
						<xsl:attribute name="href">
							edit-product?Id=<xsl:value-of select="Id"/>
						</xsl:attribute>
						<i class="fa-solid fa-eye"></i>
					</a>
				</td>
			</tr>
		</xsl:for-each>
	</xsl:template>
</xsl:stylesheet>

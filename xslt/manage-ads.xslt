<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
	<xsl:template match="/">
		<xsl:for-each select="Advertisements/Ad">
			<tr>
				<td>
					<xsl:value-of select="Id"/>
				</td>
				<td>
					<xsl:value-of select="ImageUrl"/>
				</td>
				<td>
					<xsl:value-of select="NavigateUrl"/>
				</td>
				<td>
					<xsl:value-of select="AlternateText"/>
				</td>
				<td>
					<xsl:value-of select="Keyword"/>
				</td>
				<td>
					<xsl:value-of select="Impressions"/>
				</td>
				<td>
					<a style="color: black;">
						<xsl:attribute name="href">
							edit-ads?Id=<xsl:value-of select="Id"/>
						</xsl:attribute>
						<i class="fa-solid fa-eye"></i>
					</a>
				</td>
			</tr>
		</xsl:for-each>
	</xsl:template>
</xsl:stylesheet>
<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
	<xsl:template match="/">
		<xsl:for-each select="users/user">
			<tr>
				<td>
					<xsl:value-of select="Id"/>
				</td>
				<td>
					<xsl:value-of select="first_name"/>
					<xsl:text>&#xA0;</xsl:text>
					<xsl:value-of select="last_name"/>
				</td>
				<td>
					<xsl:value-of select="phone"/>
				</td>
				<td>
					<xsl:value-of select="email"/>
				</td>
				<td>
					<xsl:value-of select="user_type"/>
				</td>
				<td>
					<a style="color: black;">
						<xsl:attribute name="href">
							edit-user?Id=<xsl:value-of select="Id"/>
						</xsl:attribute>
						<i class="fa-solid fa-eye"></i>
					</a>
				</td>
			</tr>
		</xsl:for-each>
	</xsl:template>
</xsl:stylesheet>

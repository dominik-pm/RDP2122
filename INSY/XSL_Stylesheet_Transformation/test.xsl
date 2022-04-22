<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="TVSCHEDULE">
		<html>
			<head>
				<title>TEST</title>
			</head>
			<body>
				
					<xsl:for-each select="./CHANNEL">
						<p>
							<xsl:value-of select="@CHAN"/>
						</p>
						<xsl:variable name="banner" select="./BANNER"></xsl:variable>
						<img src="{$banner}" width="108px"></img>
					</xsl:for-each>
					<div>
						<h1>Alle Programme</h1>
						<ul>
							<xsl:for-each select="./CHANNEL/DAY/PROGRAMSLOT">
								<xsl:choose>
									<xsl:when test="position() mod 2 = 0">
										<li style="background-color:#ddd">
											<xsl:value-of select="TITLE"/>
										</li>		
									</xsl:when>
									<xsl:otherwise>
										<li>
											<xsl:value-of select="TITLE"/>
										</li>
									</xsl:otherwise>
								</xsl:choose>
								
							</xsl:for-each>
						</ul>
					</div>
			</body>
		</html>	
	</xsl:template>
</xsl:stylesheet>
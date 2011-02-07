<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:msprop="urn:schemas-microsoft-com:xml-msprop" xmlns:mstns="http://stylecopcmd.sourceforge.net/StyleCopReport.xsd" xmlns:n1="urn:schemas-microsoft-com:xml-msdatasource" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com" xpath-default-namespace="mstns">
    <xsl:output version="4.0" method="html" indent="no" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd" />
    <xsl:param name="SV_OutputFormat" select="'HTML'" />
    <xsl:variable name="XML" select="/" />
    <xsl:template match="/">
        <html>
            <head>
                <title />
            </head>
            <body>
                <xsl:for-each select="StyleCopViolations">
                    <h3 style="color:navy; font-family:verdana; ">
                        <span>
                            <xsl:text>Style Cop Report</xsl:text>
                        </span>
                    </h3>
                    <span style="font-family:Verdana ! important; font-size:12px; font-weight:bold; ">
                        <xsl:text>Total Number of Violations</xsl:text>
                    </span>
                    <span style="font-family:Verdana ! important; font-size:12px; ">
                        <xsl:text>: </xsl:text>
                    </span>
                    <span style="color:#0080ff; font-family:Verdana ! important; font-size:12px; ">
                        <xsl:value-of select="count( Violation )" />
                    </span>
                    <br />
                    <br />
                    <table style="font-family:verdana; font-size:12px; width:100%;" border="0" cellpadding="3" width="100%">
                        <tbody>
                            <tr>
                                <td style="width:80px;">
									<xsl:text>Line Number</xsl:text>
                                </td>
                                <td style="width:300px;" width="300px">
									<xsl:text>Violation</xsl:text>
                                </td>
                                <td>
									<xsl:text>Path</xsl:text>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <xsl:for-each select="Violation">
						<table style="cursor:pointer; font-family:verdana; font-size:12px; width:100%; " border="0" cellpadding="3" width="100%">
							<tbody>
								<tr style="background-color:#f0f0f0;">
									<td style="width:80px;">
										<xsl:value-of select="@LineNumber"/>
									</td>
									<td style="width:250px;" width="300px">
										<xsl:value-of select="@Rule"/>
									</td>
									<td>
										<xsl:value-of select="@Source"/>
									</td>
								</tr>
							</tbody>
						</table>
                    </xsl:for-each>
                </xsl:for-each>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>

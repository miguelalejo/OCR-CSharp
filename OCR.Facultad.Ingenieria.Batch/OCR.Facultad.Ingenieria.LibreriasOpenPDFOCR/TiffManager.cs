using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;		 
using System.Collections;

namespace AMA.Util
{
	/// <summary>
	/// Presenta una serie de métodos para el manejo de archivos TIFF.
	/// </summary>
	public class TiffManager : IDisposable
	{
        /// <summary>
        /// Nombre del archivo TIFF.
        /// </summary>
		private string _ImageFileName;
        /// <summary>
        /// Número de páginas del archivo TIFF.
        /// </summary>
		private int _PageNumber;
        /// <summary>
        /// Objeto tipo Imagen del archivo TIFF.
        /// </summary>
		private Image image;
        /// <summary>
        /// Ruta temporal cuando se realiza una operación de particionamiento del documento.
        /// </summary>
		private string _TempWorkingDir;
        /// <summary>
        /// Constructor para el manejador de documentos TIFF.
        /// </summary>
        /// <param name="imageFileName">Ruta del archivo TIFF</param>
		public TiffManager(string imageFileName)
		{
            
                this._ImageFileName = imageFileName;
                image = Image.FromFile(_ImageFileName);
                GetPageNumber();
           
		}
		/// <summary>
		/// Constructor por defecto.
		/// </summary>
		public TiffManager(){
		}

		/// <summary>
		/// Lee la imagen para obtener el número de páginas.
		/// </summary>
		private void GetPageNumber(){
			Guid objGuid=image.FrameDimensionsList[0];
			FrameDimension objDimension=new FrameDimension(objGuid);

			//Gets the total number of frames in the .tiff file
			_PageNumber=image.GetFrameCount(objDimension);
			
			return;
		}

		/// <summary>
		/// Lee el string base de la Imagen,
		/// Assert(GetFileNameStartString(@"c:\test\abc.tif"),"abc")
		/// </summary>
		/// <param name="strFullName"></param>
		/// <returns></returns>
		private string GetFileNameStartString(string strFullName){
			int posDot=_ImageFileName.LastIndexOf(".");
			int posSlash=_ImageFileName.LastIndexOf(@"\");
			return _ImageFileName.Substring(posSlash+1,posDot-posSlash-1);
		}

		/// <summary>
		/// Esta función permite la salida de una imagen TIFF, en multiples arhcivos de imagen, con un formato de compresión específico.
		/// </summary>
		/// <param name="outPutDirectory">Directorio de salida del archivo TIFF segementados </param>
		/// <param name="format">El codec de compresión</param>
		/// <returns>Array list con los nombres de los arhivos seccionados</returns>
		public ArrayList SplitTiffImage(string outPutDirectory,EncoderValue format)
		{
			string fileStartString=outPutDirectory+"\\"+GetFileNameStartString(_ImageFileName);
			ArrayList splitedFileNames=new ArrayList();
			try{
				Guid objGuid=image.FrameDimensionsList[0];
				FrameDimension objDimension=new FrameDimension(objGuid);

				//Saves every frame as a separate file.
				Encoder enc=Encoder.Compression;
				int curFrame=0;
				for (int i=0;i<_PageNumber;i++)
				{
					image.SelectActiveFrame(objDimension,curFrame);
					EncoderParameters ep=new EncoderParameters(1);
					ep.Param[0]=new EncoderParameter(enc,(long)format);
					ImageCodecInfo info=GetEncoderInfo("image/tiff");
					
					//Save the master bitmap
					string fileName=string.Format("{0}{1}.TIF",fileStartString,i.ToString());
					image.Save(fileName,info,ep);
					splitedFileNames.Add(fileName);

					curFrame++;
				}	
			}catch (Exception){
				throw;
			}
			
			return splitedFileNames;
		}

		/// <summary>
		/// Esta funcion reune archivos de imagen en un único archivo TIFF, con un formato de compresión específico.
		/// </summary>
		/// <param name="imageFiles">String array con la ruta de los archivos de imagen.</param>
		/// <param name="outFile">Destino de documento TIFF producido</param>
		/// <param name="compressEncoder">Codec de Compresión</param>
		public void JoinTiffImages(string[] imageFiles,string outFile,EncoderValue compressEncoder)
		{
			try{
				//If only one page in the collection, copy it directly to the target file.
				if (imageFiles.Length==1)
				{
					File.Copy(imageFiles[0],outFile,true);
					return;
				}

				//use the save encoder
				Encoder enc=Encoder.SaveFlag;

				EncoderParameters ep=new EncoderParameters(2);
				ep.Param[0]=new EncoderParameter(enc,(long)EncoderValue.MultiFrame); 
				ep.Param[1] = new EncoderParameter(Encoder.Compression,(long)compressEncoder); 

				Bitmap pages=null;
				int frame=0;
				ImageCodecInfo info=GetEncoderInfo("image/tiff");


				foreach(string strImageFile in imageFiles)
				{
					if(frame==0)
					{
						pages=(Bitmap)Image.FromFile(strImageFile);

						//save the first frame
						pages.Save(outFile,info,ep);
					}
					else
					{
						//save the intermediate frames
						ep.Param[0]=new EncoderParameter(enc,(long)EncoderValue.FrameDimensionPage);

						Bitmap bm=(Bitmap)Image.FromFile(strImageFile);
						pages.SaveAdd(bm,ep);
					}        

					if(frame==imageFiles.Length-1)
					{
						//flush and close.
						ep.Param[0]=new EncoderParameter(enc,(long)EncoderValue.Flush);
						pages.SaveAdd(ep);
					} 

					frame++;
				}
			}catch (Exception){
				throw;
			}
			
			return;
		}

		/// <summary>
		/// This function will join the TIFF file with a specific compression format
		/// </summary>
		/// <param name="imageFiles">array list with source image files</param>
		/// <param name="outFile">target TIFF file to be produced</param>
		/// <param name="compressEncoder">compression codec enum</param>
		public void JoinTiffImages(ArrayList imageFiles,string outFile,EncoderValue compressEncoder)
		{
			try
			{
				//If only one page in the collection, copy it directly to the target file.
				if (imageFiles.Count==1){
					File.Copy((string)imageFiles[0],outFile,true);
					return;
				}

				//use the save encoder
				Encoder enc=Encoder.SaveFlag;

				EncoderParameters ep=new EncoderParameters(2);
				ep.Param[0]=new EncoderParameter(enc,(long)EncoderValue.MultiFrame); 
				ep.Param[1] = new EncoderParameter(Encoder.Compression,(long)compressEncoder); 

				Bitmap pages=null;
				int frame=0;
				ImageCodecInfo info=GetEncoderInfo("image/tiff");


				foreach(string strImageFile in imageFiles)
				{
					if(frame==0)
					{
						pages=(Bitmap)Image.FromFile(strImageFile);

						//save the first frame
						pages.Save(outFile,info,ep);
					}
					else
					{
						//save the intermediate frames
						ep.Param[0]=new EncoderParameter(enc,(long)EncoderValue.FrameDimensionPage);

						Bitmap bm=(Bitmap)Image.FromFile(strImageFile);
						pages.SaveAdd(bm,ep);
						bm.Dispose();
					}        

					if(frame==imageFiles.Count-1)
					{
						//flush and close.
						ep.Param[0]=new EncoderParameter(enc,(long)EncoderValue.Flush);
						pages.SaveAdd(ep);
					} 

					frame++;
				}
			}
			catch (Exception ex)
			{
#if DEBUG
				Console.WriteLine(ex.Message);
#endif
                throw;
			}
			
			return;
		}

		/// <summary>
		/// Remueve una pagina especifica y el resultado es almacenado en un arhivo de imagen.
		/// </summary>
		/// <param name="pageNumber">Número de pagina a remover.</param>
		/// <param name="compressEncoder">Compresión despues de la operación.</param>
		/// <param name="strFileName">Ruta de salida para el archivo de imagen.</param>
		/// <returns></returns>
		public void RemoveAPage(int pageNumber,EncoderValue compressEncoder,string strFileName){
			try
			{
				//Split the image files to single pages.
				ArrayList arrSplited=SplitTiffImage(this._TempWorkingDir,compressEncoder);
				
				//Remove the specific page from the collection
				string strPageRemove=string.Format("{0}\\{1}{2}.TIF",_TempWorkingDir,GetFileNameStartString(this._ImageFileName),pageNumber);
				arrSplited.Remove(strPageRemove);

				JoinTiffImages(arrSplited,strFileName,compressEncoder);
			}
			catch(Exception)
			{
				throw;
			}

			return;
		}

		/// <summary>
		/// Obtener la informacion de codec especificado.
		/// </summary>
		/// <param name="mimeType">Descricpición del tipo mime.</param>
		/// <returns>Informacion de codificador de Imagen.</returns>
		private ImageCodecInfo GetEncoderInfo(string mimeType){
			ImageCodecInfo[] encoders=ImageCodecInfo.GetImageEncoders();
			for (int j=0;j<encoders.Length;j++){
				if (encoders[j].MimeType==mimeType)
					return encoders[j];
			}
			
			throw new Exception( mimeType + " mime type not found in ImageCodecInfo" );
		}

		/// <summary>
		/// Retorna la Imagen de una página específica.
		/// </summary>
		/// <param name="pageNumber">Número de la página a ser extraida.</param>
		/// <returns>Objeto tipo IMAGE</returns>
		public Image GetSpecificPage(int pageNumber)
		{
			MemoryStream ms=null;
			Image retImage=null;
			try
			{
                using (ms = new MemoryStream())
                {
                    Guid objGuid = image.FrameDimensionsList[0];
                    FrameDimension objDimension = new FrameDimension(objGuid);
                    image.SelectActiveFrame(objDimension, pageNumber);
                    image.Save(ms, ImageFormat.Bmp);
                    retImage = Image.FromStream(ms);
                    return retImage;
                }
			}
			catch (Exception)
			{
				ms.Close();
				retImage.Dispose();
				throw;
			}
		}
        /// <summary>
        /// Retorna la Imagen de una página específica.
        /// </summary>
        /// <param name="pageNumber">Número de la página a ser extraida.</param>
        /// <returns>Objeto tipo IMAGE</returns>
        public Image GetSpecificPageTIF(int pageNumber)
        {
            MemoryStream ms = null;
            Image retImage = null;
            try
            {
                using (ms = new MemoryStream())
                {
                    Guid objGuid = image.FrameDimensionsList[0];
                    FrameDimension objDimension = new FrameDimension(objGuid);

                    image.SelectActiveFrame(objDimension, pageNumber);
                    EncoderParameters parm = new EncoderParameters(1);
                    EncoderParameter pa = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionCCITT3);
                    parm.Param[0] = pa;
                    image.Save(ms, GetEncoder(ImageFormat.Tiff),parm);

                    retImage = Image.FromStream(ms);

                    return retImage;
                }
            }
            catch (Exception)
            {
                ms.Close();
                retImage.Dispose();
                throw;
            }
        }
        /// <summary>
        /// Obtiene la Información del Encoder según el formato de la imagen.
        /// </summary>
        /// <param name="format">Formato del archivo de imagen(TIF,JPG,BMP,etc).</param>
        /// <returns></returns>
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

		/// <summary>
		/// Convertir el TIFF existente a un formato diferente.
		/// </summary>
        /// <param name="strNewImageFileName">Ruta del nuevo archivo de Imagen.</param>
		/// <param name="compressEncoder">Compresión de la Imagen.</param>
		/// <returns></returns>
		public void ConvertTiffFormat(string strNewImageFileName,EncoderValue compressEncoder)
		{
			//Split the image files to single pages.
			ArrayList arrSplited=SplitTiffImage(this._TempWorkingDir,compressEncoder);
			JoinTiffImages(arrSplited,strNewImageFileName,compressEncoder);

			return;
		}

		/// <summary>
		/// Nombre del archivo de Imagen.
		/// </summary>
		public string ImageFileName
		{
			get
			{
				return _ImageFileName;
			}
			set{
				_ImageFileName=value;
			}
		}

		/// <summary>
		/// Directorio Buffering 
		/// </summary>
		public string TempWorkingDir
		{
			get
			{
				return _TempWorkingDir;
			}
			set{
				_TempWorkingDir=value;
			}
		}

		/// <summary>
		/// Número de páginas de la Imagen.
		/// </summary>
		public int PageNumber
		{
			get
			{
				return _PageNumber;
			}
		}

	
		#region IDisposable Members
        /// <summary>
        /// Método utilizado para eliminar el objeto actual, heredado de la clase Object.
        /// </summary>
		public void Dispose()
		{
			image.Dispose();
			System.GC.SuppressFinalize(this);
		}

		#endregion
	}
}

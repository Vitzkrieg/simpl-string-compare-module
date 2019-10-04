using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace UserModule_COMPARESTRINGS
{
    public class UserModuleClass_COMPARESTRINGS : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput ENABLE;
        Crestron.Logos.SplusObjects.DigitalInput IGNORE_CASE;
        Crestron.Logos.SplusObjects.StringInput FIRST_STRING__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput SECOND_STRING__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput EQUAL;
        Crestron.Logos.SplusObjects.DigitalOutput FIRST_BEFORE;
        Crestron.Logos.SplusObjects.DigitalOutput SECOND_BEFORE;
        private void CHECKSTRINGS (  SplusExecutionContext __context__ ) 
            { 
            CrestronString FIRST__DOLLAR__;
            FIRST__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 254, this );
            
            CrestronString SECOND__DOLLAR__;
            SECOND__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 254, this );
            
            short COMPRESULT = 0;
            
            
            __context__.SourceCodeLine = 53;
            EQUAL  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 54;
            FIRST_BEFORE  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 55;
            SECOND_BEFORE  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 57;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ENABLE  .Value == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 58;
                return ; 
                } 
            
            __context__.SourceCodeLine = 61;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IGNORE_CASE  .Value == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 62;
                FIRST__DOLLAR__  .UpdateValue ( Functions.Lower ( FIRST_STRING__DOLLAR__ )  ) ; 
                __context__.SourceCodeLine = 63;
                SECOND__DOLLAR__  .UpdateValue ( Functions.Lower ( SECOND_STRING__DOLLAR__ )  ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 65;
                FIRST__DOLLAR__  .UpdateValue ( FIRST_STRING__DOLLAR__  ) ; 
                __context__.SourceCodeLine = 66;
                SECOND__DOLLAR__  .UpdateValue ( SECOND_STRING__DOLLAR__  ) ; 
                } 
            
            __context__.SourceCodeLine = 69;
            COMPRESULT = (short) ( Functions.CompareStrings( FIRST__DOLLAR__ , SECOND__DOLLAR__ ) ) ; 
            __context__.SourceCodeLine = 71;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (COMPRESULT == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 72;
                EQUAL  .Value = (ushort) ( 1 ) ; 
                } 
            
            __context__.SourceCodeLine = 74;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( COMPRESULT < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 75;
                FIRST_BEFORE  .Value = (ushort) ( 1 ) ; 
                } 
            
            __context__.SourceCodeLine = 77;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( COMPRESULT > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 78;
                SECOND_BEFORE  .Value = (ushort) ( 1 ) ; 
                } 
            
            
            }
            
        object ENABLE_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 89;
                CHECKSTRINGS (  __context__  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    public override object FunctionMain (  object __obj__ ) 
        { 
        try
        {
            SplusExecutionContext __context__ = SplusFunctionMainStartCode();
            
            __context__.SourceCodeLine = 101;
            EQUAL  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 102;
            FIRST_BEFORE  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 103;
            SECOND_BEFORE  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 105;
            WaitForInitializationComplete ( ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        SocketInfo __socketinfo__ = new SocketInfo( 1, this );
        InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
        _SplusNVRAM = new SplusNVRAM( this );
        
        ENABLE = new Crestron.Logos.SplusObjects.DigitalInput( ENABLE__DigitalInput__, this );
        m_DigitalInputList.Add( ENABLE__DigitalInput__, ENABLE );
        
        IGNORE_CASE = new Crestron.Logos.SplusObjects.DigitalInput( IGNORE_CASE__DigitalInput__, this );
        m_DigitalInputList.Add( IGNORE_CASE__DigitalInput__, IGNORE_CASE );
        
        EQUAL = new Crestron.Logos.SplusObjects.DigitalOutput( EQUAL__DigitalOutput__, this );
        m_DigitalOutputList.Add( EQUAL__DigitalOutput__, EQUAL );
        
        FIRST_BEFORE = new Crestron.Logos.SplusObjects.DigitalOutput( FIRST_BEFORE__DigitalOutput__, this );
        m_DigitalOutputList.Add( FIRST_BEFORE__DigitalOutput__, FIRST_BEFORE );
        
        SECOND_BEFORE = new Crestron.Logos.SplusObjects.DigitalOutput( SECOND_BEFORE__DigitalOutput__, this );
        m_DigitalOutputList.Add( SECOND_BEFORE__DigitalOutput__, SECOND_BEFORE );
        
        FIRST_STRING__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( FIRST_STRING__DOLLAR____AnalogSerialInput__, 254, this );
        m_StringInputList.Add( FIRST_STRING__DOLLAR____AnalogSerialInput__, FIRST_STRING__DOLLAR__ );
        
        SECOND_STRING__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( SECOND_STRING__DOLLAR____AnalogSerialInput__, 254, this );
        m_StringInputList.Add( SECOND_STRING__DOLLAR____AnalogSerialInput__, SECOND_STRING__DOLLAR__ );
        
        
        ENABLE.OnDigitalChange.Add( new InputChangeHandlerWrapper( ENABLE_OnChange_0, false ) );
        IGNORE_CASE.OnDigitalChange.Add( new InputChangeHandlerWrapper( ENABLE_OnChange_0, false ) );
        FIRST_STRING__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( ENABLE_OnChange_0, false ) );
        SECOND_STRING__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( ENABLE_OnChange_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_COMPARESTRINGS ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint ENABLE__DigitalInput__ = 0;
    const uint IGNORE_CASE__DigitalInput__ = 1;
    const uint FIRST_STRING__DOLLAR____AnalogSerialInput__ = 0;
    const uint SECOND_STRING__DOLLAR____AnalogSerialInput__ = 1;
    const uint EQUAL__DigitalOutput__ = 0;
    const uint FIRST_BEFORE__DigitalOutput__ = 1;
    const uint SECOND_BEFORE__DigitalOutput__ = 2;
    
    [SplusStructAttribute(-1, true, false)]
    public class SplusNVRAM : SplusStructureBase
    {
    
        public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
        
        
    }
    
    SplusNVRAM _SplusNVRAM = null;
    
    public class __CEvent__ : CEvent
    {
        public __CEvent__() {}
        public void Close() { base.Close(); }
        public int Reset() { return base.Reset() ? 1 : 0; }
        public int Set() { return base.Set() ? 1 : 0; }
        public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
    }
    public class __CMutex__ : CMutex
    {
        public __CMutex__() {}
        public void Close() { base.Close(); }
        public void ReleaseMutex() { base.ReleaseMutex(); }
        public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
    }
     public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}

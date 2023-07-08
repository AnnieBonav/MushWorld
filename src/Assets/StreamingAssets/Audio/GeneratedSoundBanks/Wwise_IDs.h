/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID PLAY_BACKGROUNDMUSIC = 548088167U;
        static const AkUniqueID PLAY_BUBBLES = 3381697299U;
        static const AkUniqueID PLAY_FOOD = 2663980450U;
        static const AkUniqueID PLAY_FOOTSTEPS = 3854155799U;
        static const AkUniqueID PLAY_GLASSCLINK = 2174888429U;
        static const AkUniqueID PLAY_HOVERBUTTON = 3130647524U;
        static const AkUniqueID PLAY_PLACEOBJECT = 3078336690U;
        static const AkUniqueID PLAY_POP = 2990278359U;
        static const AkUniqueID PLAY_POTIONS = 1853731994U;
        static const AkUniqueID PLAY_RIVER = 1498169336U;
        static const AkUniqueID PLAY_ROLL = 2719919427U;
        static const AkUniqueID PLAY_SELECTBUTTON = 348159706U;
        static const AkUniqueID STOP_BUBBLES = 1962155989U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace MUSIC
        {
            static const AkUniqueID GROUP = 3991942870U;

            namespace STATE
            {
                static const AkUniqueID BIRTHDAY = 3049429082U;
                static const AkUniqueID CHILL = 4294400669U;
                static const AkUniqueID DARK = 1925914845U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace MUSIC

    } // namespace STATES

    namespace SWITCHES
    {
        namespace FOOTSTEPS
        {
            static const AkUniqueID GROUP = 2385628198U;

            namespace SWITCH
            {
                static const AkUniqueID DIRT = 2195636714U;
                static const AkUniqueID GRASS = 4248645337U;
                static const AkUniqueID SNOW = 787898836U;
                static const AkUniqueID WATER = 2654748154U;
            } // namespace SWITCH
        } // namespace FOOTSTEPS

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID BACKGROUNDSTATE = 3425480588U;
        static const AkUniqueID BUBBLESINTENSITY = 3064925121U;
        static const AkUniqueID MUSICVOLUME = 2346531308U;
        static const AkUniqueID SFXVOLUME = 988953028U;
        static const AkUniqueID UIVOLUME = 3415057477U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID DEFAULT = 782826392U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID FOOTSTEPS = 2385628198U;
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID REVERBS = 3545700988U;
    } // namespace BUSSES

    namespace AUX_BUSSES
    {
        static const AkUniqueID CAVE_REVERB = 3177428469U;
        static const AkUniqueID ROOM_REVERB = 206373095U;
    } // namespace AUX_BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__

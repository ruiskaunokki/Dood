Shader "Custom/FogMask"
{
    SubShader
    {
        //очередь должна стоять после видимых объектов, но после тех, в которых будет вырезаться дыра
        Tags {"Queue" = "Geometry-1"}

        //никакого цвета, только з-буфер
        ColorMask 0
        ZWrite on

        //во время прохода ничего не делает
        Pass{}
    }
}

// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/szakdolgozatgreet.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace SzakdolgozatGRPCSzerver {
  public static partial class SzakdolgozatGreeter
  {
    static readonly string __ServiceName = "greet.SzakdolgozatGreeter";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::SzakdolgozatGRPCSzerver.Empty> __Marshaller_greet_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::SzakdolgozatGRPCSzerver.Empty.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::SzakdolgozatGRPCSzerver.User> __Marshaller_greet_User = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::SzakdolgozatGRPCSzerver.User.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::SzakdolgozatGRPCSzerver.Result> __Marshaller_greet_Result = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::SzakdolgozatGRPCSzerver.Result.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::SzakdolgozatGRPCSzerver.Empty, global::SzakdolgozatGRPCSzerver.User> __Method_List = new grpc::Method<global::SzakdolgozatGRPCSzerver.Empty, global::SzakdolgozatGRPCSzerver.User>(
        grpc::MethodType.Unary,
        __ServiceName,
        "List",
        __Marshaller_greet_Empty,
        __Marshaller_greet_User);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::SzakdolgozatGRPCSzerver.User, global::SzakdolgozatGRPCSzerver.Result> __Method_AddUser = new grpc::Method<global::SzakdolgozatGRPCSzerver.User, global::SzakdolgozatGRPCSzerver.Result>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddUser",
        __Marshaller_greet_User,
        __Marshaller_greet_Result);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::SzakdolgozatGRPCSzerver.User, global::SzakdolgozatGRPCSzerver.Result> __Method_RemoveUser = new grpc::Method<global::SzakdolgozatGRPCSzerver.User, global::SzakdolgozatGRPCSzerver.Result>(
        grpc::MethodType.Unary,
        __ServiceName,
        "RemoveUser",
        __Marshaller_greet_User,
        __Marshaller_greet_Result);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::SzakdolgozatGRPCSzerver.User, global::SzakdolgozatGRPCSzerver.Result> __Method_EnterBuilding = new grpc::Method<global::SzakdolgozatGRPCSzerver.User, global::SzakdolgozatGRPCSzerver.Result>(
        grpc::MethodType.Unary,
        __ServiceName,
        "EnterBuilding",
        __Marshaller_greet_User,
        __Marshaller_greet_Result);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::SzakdolgozatGRPCSzerver.User, global::SzakdolgozatGRPCSzerver.Result> __Method_ExitBuilding = new grpc::Method<global::SzakdolgozatGRPCSzerver.User, global::SzakdolgozatGRPCSzerver.Result>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ExitBuilding",
        __Marshaller_greet_User,
        __Marshaller_greet_Result);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::SzakdolgozatGRPCSzerver.User, global::SzakdolgozatGRPCSzerver.Result> __Method_EnterDiningHall = new grpc::Method<global::SzakdolgozatGRPCSzerver.User, global::SzakdolgozatGRPCSzerver.Result>(
        grpc::MethodType.Unary,
        __ServiceName,
        "EnterDiningHall",
        __Marshaller_greet_User,
        __Marshaller_greet_Result);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::SzakdolgozatGRPCSzerver.SzakdolgozatgreetReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of SzakdolgozatGreeter</summary>
    [grpc::BindServiceMethod(typeof(SzakdolgozatGreeter), "BindService")]
    public abstract partial class SzakdolgozatGreeterBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::SzakdolgozatGRPCSzerver.User> List(global::SzakdolgozatGRPCSzerver.Empty request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::SzakdolgozatGRPCSzerver.Result> AddUser(global::SzakdolgozatGRPCSzerver.User request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::SzakdolgozatGRPCSzerver.Result> RemoveUser(global::SzakdolgozatGRPCSzerver.User request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::SzakdolgozatGRPCSzerver.Result> EnterBuilding(global::SzakdolgozatGRPCSzerver.User request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::SzakdolgozatGRPCSzerver.Result> ExitBuilding(global::SzakdolgozatGRPCSzerver.User request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::SzakdolgozatGRPCSzerver.Result> EnterDiningHall(global::SzakdolgozatGRPCSzerver.User request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(SzakdolgozatGreeterBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_List, serviceImpl.List)
          .AddMethod(__Method_AddUser, serviceImpl.AddUser)
          .AddMethod(__Method_RemoveUser, serviceImpl.RemoveUser)
          .AddMethod(__Method_EnterBuilding, serviceImpl.EnterBuilding)
          .AddMethod(__Method_ExitBuilding, serviceImpl.ExitBuilding)
          .AddMethod(__Method_EnterDiningHall, serviceImpl.EnterDiningHall).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, SzakdolgozatGreeterBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_List, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::SzakdolgozatGRPCSzerver.Empty, global::SzakdolgozatGRPCSzerver.User>(serviceImpl.List));
      serviceBinder.AddMethod(__Method_AddUser, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::SzakdolgozatGRPCSzerver.User, global::SzakdolgozatGRPCSzerver.Result>(serviceImpl.AddUser));
      serviceBinder.AddMethod(__Method_RemoveUser, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::SzakdolgozatGRPCSzerver.User, global::SzakdolgozatGRPCSzerver.Result>(serviceImpl.RemoveUser));
      serviceBinder.AddMethod(__Method_EnterBuilding, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::SzakdolgozatGRPCSzerver.User, global::SzakdolgozatGRPCSzerver.Result>(serviceImpl.EnterBuilding));
      serviceBinder.AddMethod(__Method_ExitBuilding, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::SzakdolgozatGRPCSzerver.User, global::SzakdolgozatGRPCSzerver.Result>(serviceImpl.ExitBuilding));
      serviceBinder.AddMethod(__Method_EnterDiningHall, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::SzakdolgozatGRPCSzerver.User, global::SzakdolgozatGRPCSzerver.Result>(serviceImpl.EnterDiningHall));
    }

  }
}
#endregion
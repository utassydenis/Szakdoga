// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/szakdolgozatgreet.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace SzakdolgozatGRPCAdminKliens {
  public static partial class SzakdolgozatGreeter
  {
    static readonly string __ServiceName = "Szakdolgozat.SzakdolgozatGreeter";

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
    static readonly grpc::Marshaller<global::SzakdolgozatGRPCAdminKliens.Empty> __Marshaller_Szakdolgozat_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::SzakdolgozatGRPCAdminKliens.Empty.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::SzakdolgozatGRPCAdminKliens.UserInformation> __Marshaller_Szakdolgozat_UserInformation = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::SzakdolgozatGRPCAdminKliens.UserInformation.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::SzakdolgozatGRPCAdminKliens.DatedUserInformation> __Marshaller_Szakdolgozat_DatedUserInformation = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::SzakdolgozatGRPCAdminKliens.DatedUserInformation.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::SzakdolgozatGRPCAdminKliens.UserActivity> __Marshaller_Szakdolgozat_UserActivity = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::SzakdolgozatGRPCAdminKliens.UserActivity.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::SzakdolgozatGRPCAdminKliens.Empty, global::SzakdolgozatGRPCAdminKliens.UserInformation> __Method_ListUsers = new grpc::Method<global::SzakdolgozatGRPCAdminKliens.Empty, global::SzakdolgozatGRPCAdminKliens.UserInformation>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "ListUsers",
        __Marshaller_Szakdolgozat_Empty,
        __Marshaller_Szakdolgozat_UserInformation);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::SzakdolgozatGRPCAdminKliens.DatedUserInformation, global::SzakdolgozatGRPCAdminKliens.UserActivity> __Method_ListUserActivity = new grpc::Method<global::SzakdolgozatGRPCAdminKliens.DatedUserInformation, global::SzakdolgozatGRPCAdminKliens.UserActivity>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "ListUserActivity",
        __Marshaller_Szakdolgozat_DatedUserInformation,
        __Marshaller_Szakdolgozat_UserActivity);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::SzakdolgozatGRPCAdminKliens.SzakdolgozatgreetReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for SzakdolgozatGreeter</summary>
    public partial class SzakdolgozatGreeterClient : grpc::ClientBase<SzakdolgozatGreeterClient>
    {
      /// <summary>Creates a new client for SzakdolgozatGreeter</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public SzakdolgozatGreeterClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for SzakdolgozatGreeter that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public SzakdolgozatGreeterClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected SzakdolgozatGreeterClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected SzakdolgozatGreeterClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncServerStreamingCall<global::SzakdolgozatGRPCAdminKliens.UserInformation> ListUsers(global::SzakdolgozatGRPCAdminKliens.Empty request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ListUsers(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncServerStreamingCall<global::SzakdolgozatGRPCAdminKliens.UserInformation> ListUsers(global::SzakdolgozatGRPCAdminKliens.Empty request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_ListUsers, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncServerStreamingCall<global::SzakdolgozatGRPCAdminKliens.UserActivity> ListUserActivity(global::SzakdolgozatGRPCAdminKliens.DatedUserInformation request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ListUserActivity(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncServerStreamingCall<global::SzakdolgozatGRPCAdminKliens.UserActivity> ListUserActivity(global::SzakdolgozatGRPCAdminKliens.DatedUserInformation request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_ListUserActivity, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override SzakdolgozatGreeterClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new SzakdolgozatGreeterClient(configuration);
      }
    }

  }
}
#endregion
